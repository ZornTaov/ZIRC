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
        public MainWindow()
        {
            InitializeComponent();
			InitializeCommands();
        }

		private void InitializeCommands()
		{
			commands.Add("help", new CommandHelp());
			commands.Add("msg", new CommandMsg());
			commands.Add("me", new CommandMe());
			commands.Add("query", new CommandQuery());
			commands.Add("raw", new CommandRaw());
			commands.Add("quit", new CommandQuit());
			commands.Add("connect", new CommandConnect());
			commands.Add("nick", new CommandNick());
			commands.Add("join", new CommandJoin());
			commands.Add("part", new CommandPart());
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
            debugNode.Tag = new LuaWindow(this, "Debug");
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
			alt_KeyDown(sender, e);
			if (e.KeyCode == Keys.Enter)
			{
				((ChatWindow)locationTree.SelectedNode.Tag).Focus();
			}
        }
		public void alt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.Down)
			{
				if (getSelectedNode() != null && getSelectedNode().NextVisibleNode != null)
				{
					locationTree.SelectedNode = getSelectedNode().NextVisibleNode;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				return;
			}
			if (e.Alt && e.KeyCode == Keys.Up)
			{
				if (getSelectedNode() != null && getSelectedNode().PrevVisibleNode != null)
				{
					locationTree.SelectedNode = getSelectedNode().PrevVisibleNode;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				return;

			}
			if (e.Alt && e.KeyCode == Keys.Left)
			{
				if (getSelectedNode().Parent != null)
				{
					locationTree.SelectedNode = getSelectedNode().Parent;
					((ChatWindow)locationTree.SelectedNode.Tag).Focus();
				}
				getSelectedNode().Collapse();
				return;
			}
			if (e.Alt && e.KeyCode == Keys.Right)
			{
				getSelectedNode().Expand();
				return;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(this, "Are you sure you want to quit?", "Exiting ZIRC", MessageBoxButtons.OKCancel);
			if (result == DialogResult.OK)
			{
				this.Close();
			}
		}
    }
}
