using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZIRC
{
    public class ChannelWindow : ChatWindow
    {
        public enum Type : byte
        {
            Channel,
            Query
        }

        public SortedList<string, User> userDict = new SortedList<string, User>();
		public string partReason = "";
        public Type type;
        public ChannelWindow(MainWindow mainWindow, string name, Type type)
            : base(mainWindow, name, (type == Type.Channel))
        {
            this.name = name;
            this.type = type;
            /* this.userList.DataSource = new BindingSource(userDict, null);
            this.userList.DisplayMember = "TValue";
            this.userList.ValueMember = "Key";  */
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
			user.Tag = new User(name);
            user.Name = name;
            userList.Nodes.Add(user);
            userList.SelectedNode = user;
			userList.Sort();
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
			Console.WriteLine(nick);
            if (this.userList.Nodes.ContainsKey(nick))
            {
				this.userList.Nodes.Remove(this.userList.Nodes[nick]);
            }
        }
    }
}
