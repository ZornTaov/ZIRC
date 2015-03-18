using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZIRCExtensions;

namespace ZIRC
{
	public partial class ChatWindow : Form
	{
		protected MainWindow mainWindow;
		protected string name;
		private Stack<string> Undo;
		private Stack<string> Redo;
		private string prevLine = "";
		public TreeNode node { get; protected set; }
		/// Public string for control code characters
		public static string A = "\u0001"; // Action Events
		public static string B = "\u0002"; // Bold control
		public static string K = "\u0003"; // Color control
		public static string U = "\u0031"; // Underline control
		public ChatWindow( MainWindow mainWindow, string name, bool hasList = false )
		{
			InitializeComponent();
			this.chatBox.Font = this.inputText.Font = Properties.Settings.Default.mainFont;
			this.mainWindow = mainWindow;
			this.Text = this.name = name;
			this.userList.Visible = hasList;
			this.splitter2.Visible = hasList;
			this.userList.ShowLines = false;
			this.userList.ShowPlusMinus = false;
			this.userList.ShowRootLines = false;
			Undo = new Stack<string>();
			Redo = new Stack<string>();
		}

		private void userList_SelectedIndexChanged( object sender, EventArgs e )
		{

		}
		public void setNode( TreeNode node )
		{
			this.node = node;
		}

		protected override void OnClosed( EventArgs e )
		{
			this.mainWindow.locationTree.Nodes.Remove( this.node );
			base.OnClosed( e );
		}
		private void inputText_KeyPress( object sender, KeyPressEventArgs e )
		{

			if ( e.KeyChar == (char)Keys.Enter )
			{
				if ( inputText.Text.Equals( "" ) )
				{
					e.Handled = true;
					return;
				}
				if ( !prevLine.Equals( "" ) )
				{
					Undo.Push( prevLine );
				}
				while ( Redo.Count > 0 )
				{
					Undo.Push( Redo.Pop() );
				}
				Undo.Push( inputText.Text );
				parseInput( inputText.Text, this.name );
				inputText.Clear();
				prevLine = "";
				e.Handled = true;
				// this stuff is left here for reference, will be removed later
				//userList.Visible = !userList.Visible;
				//long unixDate = 1423436287000;
				//DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				//DateTime date = start.AddMilliseconds(unixDate).ToLocalTime();
				//chatBox.AppendText(date.ToString() + " ");
				/*string pattern = @"\((.+)\)(.+)";
				Match result = Regex.Match(inputText.Text, pattern, RegexOptions.IgnoreCase);
				if (result.Success)
					chatBox.AppendText(result.Groups[1].ToString() + " " + result.Groups[2].ToString());*/

			}

		}

		public virtual void main_KeyDown( object sender, KeyEventArgs e )
		{

			if ( mainWindow.alt_KeyDown( sender, e ) ) return;

			if ( sender is TextBox && ( (TextBox)sender ).Name.Equals( "inputText" ) && e.KeyCode == Keys.Up )
			{
				if ( !prevLine.Equals( "" ) )
				{
					Redo.Push( prevLine );
				}
				this.prevLine = inputText.Text = Undo.Count > 0 ? Undo.Pop() : "";
				inputText.Select( inputText.Text.Length, 0 );
			}
			if ( sender is TextBox && ( (TextBox)sender ).Name.Equals( "inputText" ) && e.KeyCode == Keys.Down )
			{
				if ( !prevLine.Equals( "" ) )
				{
					Undo.Push( prevLine );
				}
				this.prevLine = inputText.Text = Redo.Count > 0 ? Redo.Pop() : "";
				inputText.Select( inputText.Text.Length, 0 );
			}
		}
		protected virtual void ChatWindow_Activated( Object sender, EventArgs e )
		{
			mainWindow.locationTree.SelectedNode = this.node;
			this.inputText.Focus();
		}

		public virtual void parseInput( string text, string channel = "" )
		{
			printText( text );
		}

		public virtual void print( params object[] text )
		{
			if ( text == null ) text = new object[] { "nil" };
			string line = "";
			foreach ( object item in text )
			{
				line += ( item == null ? "nil" : item.ToString() ) + "\t";
			}
			printText( line );
		}

		public virtual void printText( string text )
		{
			Color oFore = chatBox.SelectionColor;// = Color.FromKnownColor( KnownColor.WindowText );
			Color oBack = chatBox.SelectionBackColor;// = Color.FromKnownColor( KnownColor.Window );
			Color fore = oFore;
			Color back = oBack;
			Font oFont = Properties.Settings.Default.mainFont;
			chatBox.Suspend();

			chatBox.Select( chatBox.Text.Length, 0 );
			chatBox.SelectionFont = oFont;
			chatBox.AppendText( "[" + DateTime.Now.ToShortTimeString() + "] " );

			bool under = false, color = false, bold = false;
			int i = 0;
			while ( i < text.Length )
			{

				switch ( (char)text[i] )
				{
					case (char)ControlCode.Bold:
						bold = !bold;
						i++;
						continue;
					case (char)ControlCode.Underline:
					case (char)ControlCode.Underline2:
						under = !under;
						i++;
						continue;
					case (char)ControlCode.Color:
						// try to match the color regex
						Match match = IRCRegex.color.Match( text, i );
						if ( match.Success )
						{
							color = true;
							fore = Color.FromName( ( (ColorCode)int.Parse( match.Groups["fore"].Value.ToString() ) ).ToString() );
							if ( !match.Groups["back"].Value.Equals( "" ) )
							{
								back = Color.FromName( ( (ColorCode)int.Parse( match.Groups["back"].Value.ToString() ) ).ToString() );
							}
							i += match.Length;
						}
						else
						{
							back = oBack;
							fore = oFore;
							i++;
							color = false;
						}

						continue;
				}
				if ( i < text.Length )
				{
					chatBox.AppendText( text[i].ToString() );
				}

				if ( bold || under || color )
				{
					//color here
					if ( color )
					{
						chatBox.Select( chatBox.Text.Length - 1, 1 );
						chatBox.SelectionColor = fore;
						chatBox.Select( chatBox.Text.Length - 1, 1 );
						chatBox.SelectionBackColor = back;
					}
					chatBox.Select( chatBox.Text.Length - 1, 1 );
					chatBox.SelectionFont = new Font( oFont, setBold( bold ) | setUnderline( under ) );
				}
				chatBox.Select( chatBox.Text.Length, 0 );
				chatBox.SelectionColor = oFore;
				chatBox.SelectionBackColor = oBack;
				chatBox.SelectionFont = oFont;
				i++;
			}
			chatBox.Resume();
			chatBox.AppendText( Environment.NewLine );
		}

		private FontStyle setBold( bool bold )
		{
			return bold ? FontStyle.Bold : FontStyle.Regular;
		}

		private FontStyle setUnderline( bool underline )
		{
			return underline ? FontStyle.Underline : FontStyle.Regular;
		}

		public void timer1_Tick( object sender, EventArgs e )
		{
			timer1_Ticker( sender, e );
		}
		public virtual void timer1_Ticker( object sender, EventArgs e ) { }

		public virtual void toggleOpToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		public virtual void toggleVoiceToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		public virtual void kickUserToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		public virtual void whoisToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		public virtual void queryToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		public virtual void inputText_MouseDown( object sender, MouseEventArgs e )
		{

		}

		private void chatBox_TextChanged( object sender, EventArgs e )
		{
			chatBox.SelectionStart = chatBox.Text.Length;
			chatBox.ScrollToCaret();
		}

		private void chaBox_LinkClicked( object sender, LinkClickedEventArgs e )
		{
			System.Diagnostics.Process.Start( e.LinkText );
		}
	}
}
