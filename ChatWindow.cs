using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ZIRC
{
	public partial class ChatWindow : Form
	{
		protected MainWindow mainWindow;
		protected string name;
		public Stack<string> Undo { get; set; }
		public Stack<string> Redo { get; set; }
		public TreeNode node { get; protected set; }
		/// Public string for control code characters
		public string A = "\u0001"; // Action Events
		public string B = "\u0002"; // Bold control
		public string K = "\u0003"; // Color control
		public string U = "\u0031"; // Underline control
		public ChatWindow(MainWindow mainWindow, string name, bool hasList = false)
		{
			InitializeComponent();
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

		private void userList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		public void setNode(TreeNode node)
		{
			this.node = node;
		}

		protected override void OnClosed(EventArgs e)
		{
			this.mainWindow.locationTree.Nodes.Remove(this.node);
			base.OnClosed(e);
		}
		private void inputText_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			if (e.KeyChar == (char)Keys.Enter )
			{
				if (string.IsNullOrEmpty(inputText.Text))
				{
					e.Handled = true;
					return;
				}
				Undo.Push(inputText.Text);
				parseInput(inputText.Text, this.name);
				inputText.Clear();
				e.Handled = true;
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

		public void main_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.Down)
			{
				if (mainWindow.getSelectedNode() != null && mainWindow.getSelectedNode().NextVisibleNode != null)
				{
					mainWindow.locationTree.SelectedNode = mainWindow.getSelectedNode().NextVisibleNode;
					((ChatWindow)mainWindow.locationTree.SelectedNode.Tag).Focus();
				}
				return;
			}
			if (e.Alt && e.KeyCode == Keys.Up)
			{
				if (mainWindow.getSelectedNode() != null && mainWindow.getSelectedNode().PrevVisibleNode != null)
				{
					mainWindow.locationTree.SelectedNode = mainWindow.getSelectedNode().PrevVisibleNode;
					((ChatWindow)mainWindow.locationTree.SelectedNode.Tag).Focus();
				}
				return;
					
			}
			if (e.Alt && e.KeyCode == Keys.Left)
			{
				if(mainWindow.getSelectedNode().Parent != null)
				{
					mainWindow.locationTree.SelectedNode = mainWindow.getSelectedNode().Parent;
					((ChatWindow)mainWindow.locationTree.SelectedNode.Tag).Focus();
				}
				mainWindow.getSelectedNode().Collapse();
				return;
			}
			if (e.Alt && e.KeyCode == Keys.Right)
			{
				mainWindow.getSelectedNode().Expand();
				return;
			}

			if (sender is TextBox && ((TextBox)sender).Name.Equals("inputText") && e.KeyCode == Keys.Up)
			{
				if (Undo.Count == 0) // do a history thing
				{
					return;
				}
				Redo.Push(inputText.Text);
				inputText.Text = Undo.Pop();
				inputText.Select(inputText.Text.Length, 0);
			}
			if (sender is TextBox && ((TextBox)sender).Name.Equals("inputText") && e.KeyCode == Keys.Down)
			{
				if (Redo.Count == 0) // do a history thing
				{
					return;
				}
				Undo.Push(inputText.Text);
				inputText.Text = Redo.Pop();
				inputText.Select(inputText.Text.Length, 0);
			}
		}
		protected virtual void ChatWindow_Activated(Object sender, EventArgs e)
		{

			mainWindow.locationTree.SelectedNode = this.node;
		}

		public virtual void parseInput(string text, string channel = "")
		{
			printText(text);
		}

		public virtual void printText(string text)
		{
			chatBox.AppendText("[" + DateTime.Now.ToShortTimeString() + "] " + text + Environment.NewLine);
		}

		public void timer1_Tick(object sender, EventArgs e)
		{
			timer1_Ticker(sender, e);
		}
		public virtual void timer1_Ticker(object sender, EventArgs e) { }

		private void toggleOpToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void toggleVoiceToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void kickUserToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void whoisToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void queryToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
