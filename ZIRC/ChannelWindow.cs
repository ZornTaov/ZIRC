using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZIRCExtensions;

namespace ZIRC
{
    public class ChannelWindow : ChatWindow
    {
        public enum Type : byte
        {
            Channel,
            Query
        }

        public List<string> userDict = new List<string>();
		public string partReason = "";
        public Type type;
		//for tab completion
		int count = 0;
		int currentNameIndex = 0, firstNameIndex = 0;
		bool tabStarted = false;
		string keyword = "";
        public ChannelWindow(MainWindow mainWindow, string name, Type type)
            : base(mainWindow, name, (type == Type.Channel))
        {
			
            this.name = name;
            this.type = type;
        }
		private void updateAutoComplete(string name)
		{
			var acsc = new AutoCompleteStringCollection();
			foreach (string item in userDict.ToArray())
			{
				Console.WriteLine(item);
			}
			acsc.AddRange((string[])userDict.ToArray());
		}
		public override void parseInput(string text, string channel = "")
		{
			//this.printText(((ServerWindow)this.node.Parent.Tag).nickName + ": " +text);
			((ServerWindow)this.node.Parent.Tag).parseInput(text, channel);
		}

        public void AddAllToUserList(string names)
        {
            string[] namesSplit = names.Split(' ');
            foreach (string name in namesSplit)
            {
                AddToUserList(name);
            }
        }

        public void AddToUserList(string name)
        {
			if (name.Equals(""))
			{
				return;
			}
			Match matchMode = IRCRegex.usermode.Match(name);
			string mode = "";
			if (matchMode.Success)
			{
				mode = matchMode.Value;
				name = name.Substring(matchMode.Value.Length);
			}
			if (this.userList.Nodes.ContainsKey(name))
			{
				return;
			}
            TreeNode user = new TreeNode(mode + name);
			if(name.Contains('@'))
			{
				user.Tag = User.Parse( name );
			}
			else
			{
				user.Tag = new User( name );
			}
			
			((User)user.Tag).mode = mode;
            user.Name = name;
            userList.Nodes.Add(user);
            userList.SelectedNode = user;
			userList.Sort();
			userDict.Add(name);
			//updateAutoComplete();
        }

		public void	UpdateNick(string nick, string new_nick, string new_host)
		{
			if (nick.Equals(""))
			{
				return;
			}
			if (this.userList.Nodes.ContainsKey(nick))
			{
				string mode = ((User)this.userList.Nodes[nick].Tag).mode;
				RemoveFromUserList(nick);
				TreeNode user = new TreeNode(mode + new_nick);
				user.Tag = User.Parse(new_host);
				((User)user.Tag).mode = mode;
				user.Name = new_nick;
				userList.Nodes.Add(user);
				userList.SelectedNode = user;
				userList.Sort();
				userDict.Add(new_nick);
				//updateAutoComplete();
			}
			return;
		}

        protected override void OnClosed(EventArgs e)
        {
			if (this.type == Type.Channel)
			{
				((ServerWindow)this.node.Parent.Tag).SendRaw("PART " + name + " " + partReason);
			} 
            base.OnClosed(e);
        }

        internal void RemoveFromUserList(string nick)
		{
            if (this.userList.Nodes.ContainsKey(nick))
            {
				this.userList.Nodes.Remove(this.userList.Nodes[nick]);
				this.userDict.Remove(nick);
				//updateAutoComplete();
            }
        }

		public override void inputText_MouseDown(object sender, MouseEventArgs e)
		{
			tabStarted = false;
			count = 0;
			keyword = "";
			currentNameIndex = 0;
		}
		public override void main_KeyDown(object sender, KeyEventArgs e)
		{
			if (mainWindow.alt_KeyDown(sender, e)) return;

			if (userList.Visible)
			{
				if (sender is TextBox && ((TextBox)sender).Name.Equals("inputText") && e.KeyCode == Keys.Tab)
				{
					e.SuppressKeyPress = true;
					e.Handled = true;
					if (!tabStarted)
					{
						int lastspacepos = 0;
						if (inputText.SelectionStart == 0)
						{
							lastspacepos = 0;	
						}
						else
						{
							lastspacepos = inputText.Text.LastIndexOf(" ", inputText.SelectionStart - 1);
						}
						if (lastspacepos == -1)
						{
							lastspacepos = 0;
						}
						keyword = inputText.Text.Substring(Math.Min(lastspacepos + 1, inputText.Text.Length), Math.Min(Math.Max(inputText.SelectionStart - (lastspacepos + 1), 0), inputText.Text.Length));
						
						currentNameIndex = firstNameIndex = userDict.FindIndex(FindName);
						if (currentNameIndex == -1) return;
						string name = userDict[currentNameIndex];
						inputText.Text = inputText.Text.ReplaceAt(name, Math.Min(lastspacepos + 1, inputText.Text.Length), inputText.SelectionStart - (lastspacepos + 1));
						inputText.SelectionStart = lastspacepos + 1;
						inputText.SelectionLength = name.Length;
						tabStarted = true;
					}
					else
					{
						if (inputText.SelectionLength == 0)
						{
							inputText.SelectionLength = userDict[currentNameIndex].Length;
						}
						if (currentNameIndex + 1 > userDict.Count)
						{
							currentNameIndex = firstNameIndex;
						}
						currentNameIndex = userDict.FindIndex(currentNameIndex+1, FindName);
						if (currentNameIndex == -1) currentNameIndex = firstNameIndex;
						string name = userDict[currentNameIndex];
						inputText.Text = inputText.Text.ReplaceAt(name, inputText.SelectionStart, inputText.SelectionLength);
						
						inputText.SelectionLength = name.Length;
					}
				}
				if (sender is TextBox && ((TextBox)sender).Name.Equals("inputText") && e.KeyCode != Keys.Tab)
				{
					tabStarted = false;
					count = 0;
					keyword = "";
					currentNameIndex = 0;
				}
			}
			base.main_KeyDown(sender, e);
		}
		private bool FindName(string name)
		{
			return name.ToLower().StartsWith(this.keyword.ToLower()) || keyword.Equals("");
		}
    }
}
