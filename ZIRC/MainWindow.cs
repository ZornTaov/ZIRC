using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZIRC.Commands;
using NLua;

namespace ZIRC
{
    public partial class MainWindow : Form
    {
        IRCConfig config = new IRCConfig();
		public static SortedDictionary<string, CommandBase> commands = new SortedDictionary<string, CommandBase>();
        List<Form> windows = new List<Form>();
		public Lua state = new Lua();
		LuaWindow debug;
        public MainWindow()
        {
            InitializeComponent();
			InitializeCommands();
			InitializeLua();
        }

		private void InitializeLua()
		{
			debug = new LuaWindow( this, "Debug" );
			state.RegisterFunction( "print", debug, debug.GetType().GetMethod( "print" ) );
		}

		private void InitializeCommands()
		{
			commands.Add( "help", new CommandHelp() );
			commands.Add( "msg", new CommandMsg() );
			commands.Add( "me", new CommandMe() );
			commands.Add( "query", new CommandQuery() );
			commands.Add( "raw", new CommandRaw() );
			commands.Add( "quit", new CommandQuit() );
			commands.Add( "connect", new CommandConnect() );
			commands.Add( "nick", new CommandNick() );
			commands.Add( "join", new CommandJoin() );
			commands.Add( "part", new CommandPart() );
			commands.Add( "ctcp", new CommandCTCP() );
		}

        private void locationTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
			if (e.Node.Tag != null)
				((Form)e.Node.Tag).BringToFront();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectWindow connect = new ConnectWindow(this);
            connect.Show();
        }

        internal void newServer(ConnectWindow connectWindow)
        {
            ServerWindow serverWindow = new ServerWindow(this, connectWindow.serverBox.Text);
            IRCConfig.WriteServerConnectSettings(connectWindow);
            serverWindow.startServer(connectWindow.serverBox.Text, Int32.Parse(connectWindow.portBox.Text), connectWindow.passwordBox.Text, connectWindow.nicknameBox.Text, connectWindow.usernameBox.Text, connectWindow.realnameBox.Text, connectWindow.altNickBox1.Text, connectWindow.altNickBox2.Text);
            
            TreeNode serverNode = new TreeNode(serverWindow.address);
            serverNode.Tag = serverWindow;
            serverNode.Name = serverWindow.address;
            serverWindow.setNode(serverNode);
            ((ChatWindow)serverNode.Tag).MdiParent = this;
            ((ChatWindow)serverNode.Tag).Show();
            locationTree.Nodes.Add(serverNode);
            locationTree.SelectedNode = serverNode;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            makeDebugWindow();
        }

        private void makeDebugWindow()
        {
            TreeNode debugNode = new TreeNode("Debug");
			debugNode.Tag = debug;
            debugNode.Name = "Debug";
            ((ChatWindow)debugNode.Tag).MdiParent = this;
            ((ChatWindow)debugNode.Tag).WindowState = FormWindowState.Maximized;
            ((ChatWindow)debugNode.Tag).Show();
            ((ChatWindow)debugNode.Tag).setNode(debugNode);
            locationTree.Nodes.Add(debugNode);
            locationTree.SelectedNode = debugNode;
        }

        private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!locationTree.Nodes.ContainsKey("Debug"))
            {
                makeDebugWindow();
            }
            else
            {
                ((ChatWindow)locationTree.Nodes["Debug"].Tag).BringToFront();
            }

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (locationTree.SelectedNode.Tag is ServerWindow)
            {
                ((ServerWindow)locationTree.SelectedNode.Tag).closeServerConnection();
            }
			else if (locationTree.SelectedNode.Tag is ChannelWindow || locationTree.SelectedNode.Tag is ChannelListWindow)
			{
				((ServerWindow)locationTree.SelectedNode.Parent.Tag).closeServerConnection();
			}
            else
            {
                ((ChatWindow)locationTree.Nodes["Debug"].Tag).BringToFront();
            }
        }

		public TreeNode getSelectedNode()
		{
			return this.locationTree.SelectedNode;
		}

        public void main_KeyDown(object sender, KeyEventArgs e)
		{
			if (alt_KeyDown(sender, e)) return;
			if (e.KeyCode == Keys.Enter)
			{
				((ChatWindow)locationTree.SelectedNode.Tag).Focus();
			}
        }
		public bool alt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.Down)
			{
				if (getSelectedNode() != null && getSelectedNode().NextVisibleNode != null)
				{
					locationTree.SelectedNode = getSelectedNode().NextVisibleNode;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				return true;
			}
			if (e.Alt && e.KeyCode == Keys.Up)
			{
				if (getSelectedNode() != null && getSelectedNode().PrevVisibleNode != null)
				{
					locationTree.SelectedNode = getSelectedNode().PrevVisibleNode;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				return true;

			}
			if (e.Alt && e.KeyCode == Keys.Left)
			{
				if (getSelectedNode().Parent != null)
				{
					locationTree.SelectedNode = getSelectedNode().Parent;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				getSelectedNode().Collapse();
				return true;
			}
			if (e.Alt && e.KeyCode == Keys.Right)
			{
				getSelectedNode().Expand();
				return true;
			}
			return false;
		}

		private void Menu_Copy(Object sender, EventArgs e)
		{
			if ( !( ( (ChatWindow)getSelectedNode().Tag ).ActiveControl is TextBoxBase ) ) return;
			// Ensure that text is selected in the text box.    
			if ( ( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).SelectionLength > 0 )
				// Copy the selected text to the Clipboard.
				( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).Copy();
		}

		private void Menu_Cut(Object sender, EventArgs e)
		{
			if ( !( ( (ChatWindow)getSelectedNode().Tag ).ActiveControl is TextBoxBase ) ) return;
			// Ensure that text is currently selected in the text box.    
			if ( ( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).SelectedText.Length > 0 )
				// Cut the selected text in the control and paste it into the Clipboard.
				( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).Cut();
		}

		private void Menu_Paste(Object sender, EventArgs e)
		{
			if ( !( ( (ChatWindow)getSelectedNode().Tag ).ActiveControl is TextBoxBase ) ) return;
			// Determine if there is any text in the Clipboard to paste into the text box. 
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				// Paste current text in Clipboard into text box.
				((ChatWindow)getSelectedNode().Tag).inputText.Paste();
			}
		}


		private void Menu_Undo(Object sender, EventArgs e)
		{
			if ( !( ( (ChatWindow)getSelectedNode().Tag ).ActiveControl is TextBoxBase ) ) return;
			// Determine if last operation can be undone in text box.    
			if ( ( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).CanUndo == true )
			{
				// Undo the last operation.
				( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).Undo();
				// Clear the undo buffer to prevent last action from being redone.
				//((TextBox)((ChatWindow)getSelectedNode().Tag).ActiveControl).ClearUndo();
			}
		}

		private void Menu_SelectAll( object sender, EventArgs e )
		{
			if ( !( ( (ChatWindow)getSelectedNode().Tag ).ActiveControl is TextBoxBase ) ) return;
			( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).SelectionStart = 0;
			( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).SelectionLength = ( (TextBoxBase)( (ChatWindow)getSelectedNode().Tag ).ActiveControl ).Text.Length; 
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(this, "Are you sure you want to quit?", "Exiting ZIRC", MessageBoxButtons.OKCancel);
			if (result == DialogResult.OK)
			{
				this.Close();
			}
		}

		private void fonttemporaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = fontDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				// Get Font.
				Font font = fontDialog1.Font;
				// Set TextBox properties.
				foreach (TreeNode node in locationTree.Nodes)
				{
					((ChatWindow)node.Tag).inputText.Font = ((ChatWindow)node.Tag).chatBox.Font = font;
				}
				Properties.Settings.Default.mainFont = font;
				Properties.Settings.Default.Save();
			}
		}
    }
}
