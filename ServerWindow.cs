using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZIRC.Commands;

namespace ZIRC
{
    public class ServerWindow : ChatWindow
    {
        public enum Status : byte
        {
            Disconnected,
            Disconnecting,
            Connecting,
            Connected
        }
        public Status status { get; protected set; }
        protected TcpClient connection;
        NetworkStream sockstream;
        protected StreamWriter output;
        protected StreamReader input;
        byte[] readBuffer = new byte[65 * 1024];
        int readPos = 0;
        public string address { get; protected set; }
        private int port;
        private string password;
        public string nickName { get; protected set; }
        private string userName;
        private string realName;
        private string altNick1;
        private string altNick2;
        private byte nickAttempts = 0;

        public ServerWindow(MainWindow mainWindow, string name, bool hasList = false)
            : base(mainWindow, name, hasList)
        {
            status = Status.Disconnected;
        }
        public void startServer(string address, int port, string password, string nickName, string userName, string realName, string altNick1, string altNick2)
        {
            this.address = address;
            this.port = port;
            this.password = password;
            this.nickName = nickName;
            this.userName = userName;
            this.realName = realName;
            this.altNick1 = altNick1;
            this.altNick2 = altNick2;
            setTitle();
            connect();
        }

        public void connect()
        {
            if(status == Status.Disconnected)
            {
                status = Status.Connecting;
                try
                {
                    this.connection = new TcpClient(address, port);
                    this.chatBox.AppendText("Connecting..." + Environment.NewLine);
                    sockstream = connection.GetStream();
                    output = new StreamWriter(sockstream);// { NewLine = "\r\n", AutoFlush = true };
                    input = new StreamReader(sockstream);
                    SendRaw(String.Format("USER {0} 0 * :{0}", this.userName), false);
                    SendRaw("NICK " + this.nickName, false);
                    status = Status.Connecting;
                    //serverThread.Start();
                    this.timer1.Enabled = true;
                    this.timer1.Start();
                }
                catch (Exception e)
                {
                    this.chatBox.AppendText("A " + e.ToString() + Environment.NewLine);
                }
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            if (status != Status.Disconnected)
            {
                try
                {
                    closeServerConnection();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            if (this.node.FirstNode != null)
            {
                foreach (TreeNode child in this.node.Nodes)
                {
                    ((ChatWindow)child.Tag).Close();
                }
            }
            base.OnClosed(e);
        }

        public void closeServerConnection(string message = "goodbye")
        {
            SendRaw("QUIT :" + message + Environment.NewLine);
            timer1.Stop();
            //connection.Close();
            printText("Server Stopped");
			foreach (TreeNode window  in this.node.Nodes)
			{
				((ChatWindow)window.Tag).printText("Server Stopped");
			}
            status = Status.Disconnected;
            connection.Close();
        }
        public void SendRaw(String message, Boolean log = true)
        {
            if (status != Status.Disconnected)
            {
                //printText(message);
                byte[] bs = Encoding.Default.GetBytes(message + "\n");
                connection.GetStream().Write(bs, 0, bs.Length);
                if (log) this.chatBox.AppendText("<<< " + message + Environment.NewLine);
                Console.WriteLine(message);
            }
        }
        public override void parseInput(string text, string channel = "")
        {
            //parse stuff like /msg or if there is no "/" command

			Match match = IRCRegex.command.Match(text);
			if (match.Groups["command"] != null && !match.Groups["command"].Value.Equals(""))
            {
                //base.printText(text);
				if (MainWindow.commands.ContainsKey(match.Groups["command"].Value.ToLower()))
				{
					MainWindow.commands[match.Groups["command"].Value.ToLower()].Do(this, channel, match.Groups["args"].Value, match.Groups["text"].Value);
				}

                switch (match.Groups["command"].Value.ToLower())
                {
					/* case "me":
						SendRaw("PRIVMSG " + channel + " :" + A + "ACTION " + match.Groups["args"].Value + (match.Groups["text"] != null ? " " + match.Groups["text"].Value : "") + A);
						getChannel(channel).printText("* " + nickName + " " + text.Remove(0, 4));
						break;
					case "msg":
						SendRaw("PRIVMSG " + match.Groups["args"].Value + " :" + match.Groups["text"].Value);
						break;  */
					case "raw":
						SendRaw(text.Remove(0,5));
						break;
                    case "quit":
                        this.status = Status.Disconnecting;
                        SendRaw("QUIT " + match.Groups["args"].Value + (match.Groups["text"] != null ? " " + match.Groups["text"].Value : ""));
                        break;
                    case "connect":
                        if (this.status == Status.Disconnected)
                        {
                            connect();
                        }
                        break;
                    case "nick":
                        this.ChangeNickname(match.Groups["args"].Value);
                        break;
                    case "join":
						this.joinChannel(match.Groups["args"].Value, match.Groups["text"].Value);
                        break;
					case "kick":
						SendRaw("KICK " + match.Groups["args"] + " " + match.Groups["text"].Value);
						break;
                }
            }
            else
            {
				if (!channel.Equals(""))
				{
					SendRaw("PRIVMSG " + channel + " :" + match.Groups["text"].Value, false);
					messageChannel(this.nickName, channel, match.Groups["text"].Value);
				}
				else
				{
					this.printText(match.Groups["text"].Value);
				}
            }
        }

        private void joinChannel(string[] splitData)
        {
            this.joinChannel(splitData[1], (splitData.Length > 2 ? " " + splitData[2] : ""));
        }
        public void joinChannel(string chan, string pass = "")
        {
			if (this.status == Status.Disconnected)
			{
				return;
			}
			if (this.getChannel(chan) != null)
			{
				this.getChannel(chan).Show();
				mainWindow.locationTree.SelectedNode = this.getChannel(chan).node;
			}
			else
			{
				TreeNode channelNode = new TreeNode(chan);
				channelNode.Tag = new ChannelWindow(mainWindow, chan, ChannelWindow.Type.Channel);
				channelNode.Name = chan;
				((ChatWindow)channelNode.Tag).MdiParent = mainWindow;
				((ChatWindow)channelNode.Tag).Show();
				((ChatWindow)channelNode.Tag).setNode(channelNode);
				this.node.Nodes.Add(channelNode);
				mainWindow.locationTree.SelectedNode = channelNode;
			}
			SendRaw("JOIN " + chan + " " + pass);
        }
		public void queryUser(string user)
		{
			if (this.status == Status.Disconnected)
			{
				return;
			}
			if (this.getChannel(user) != null)
			{
				this.getChannel(user).Show();
				mainWindow.locationTree.SelectedNode = this.getChannel(user).node;
			}
			else
			{
				TreeNode queryNode = new TreeNode(user);
				queryNode.Tag = new ChannelWindow(mainWindow, user, ChannelWindow.Type.Query);
				queryNode.Name = user;
				((ChatWindow)queryNode.Tag).MdiParent = mainWindow;
				((ChatWindow)queryNode.Tag).Show();
				((ChatWindow)queryNode.Tag).setNode(queryNode);
				this.node.Nodes.Add(queryNode);
				mainWindow.locationTree.SelectedNode = queryNode;
			}
		}
        public void ChangeNickname(String nickname)
        {
            if (/*status == Status.Connected && */nickname != null && nickname != "" && nickname != this.nickName)
            {
                SendRaw("NICK :" + nickname, false);
                this.nickName = nickname;
                setTitle();
            }
        }
        public void read() // DINO'S Turbo deluxe read from server loop. DO NOT MODIFY
        {
            while (sockstream.DataAvailable)
            {
                readPos += sockstream.Read(readBuffer, readPos, readBuffer.Length - readPos);
                for (int i = 0; i < readPos; i++)
                {
                    if (readBuffer[i] == 0xA || readBuffer[i] == 0xD)
                    {
                        if (i > 0)
                            parseLine(Encoding.Default.GetString(readBuffer, 0, i));

                        // clear & continue
                        for (int j = 0; j < readPos - i - 1; j++)
                            readBuffer[j] = readBuffer[j + i + 1];

                        readPos = readPos - i - 1;
                        i = -1;
                    }
                }
            }
        }
        public override void timer1_Ticker(object sender, EventArgs e)
        {
            if (status != Status.Disconnecting)
            {
                try
                {
                    read();
                }
                catch (IOException)
                {
                    //Console.WriteLine("a " + ex);

                }

                catch (Exception ex)
                {
                    Console.WriteLine("c " + ex);
                }
            }
            else
            {
                closeServerConnection();
            }
        }

        /* private void parseLine(string line)
        {
            Console.WriteLine(line);
            printText(line);
            string[] splitData = line.Split(' ');
            if (splitData[0] == "PING")
            {
                SendRaw("PONG " + splitData[1]);
            }

            switch (splitData[1].ToLower())
            {  */
        public void parseLine(String line)
		{
			Console.WriteLine(line);
            string[] splitData = line.Split(' '); // SPLIT UP PACKET BY SPACES
            if (splitData[0] == "PING") { SendRaw("PONG " + splitData[1]); return; } //IRC KEEP ALIVE - DO NOT MODIFY

            // REGEX SPLIT DATA
            Match match = IRCRegex.coreregx.Match(line);
            
            if (match.Success)
            {

                string hostmask = match.Groups["hostmask"] != null ? match.Groups["hostmask"].Value : ""; //FULL HOSTMASK STRING ASSIGNMENT
                string command = match.Groups["command"] != null ? match.Groups["command"].Value : ""; //IRC COMMAND
                string args = match.Groups["args"] != null ? match.Groups["args"].Value : ""; //COMMAND ARGUMENTS #channel, Modes, etc.
                string text = match.Groups["text"] != null ? match.Groups["text"].Value : ""; //VARIABLE TEXT TRAILING EVENT
                string nick = "", ident = "", host = "", address = "";
                ChannelWindow chan;
				string[] argSplit;
                Match split = IRCRegex.hostsplit.Match(hostmask);
                if (split.Success)
                {
                    nick = split.Groups["nick"].Value;
                    ident = split.Groups["ident"].Value;
                    host = split.Groups["host"].Value;
                    address = ident + "@" + host;
                    
                }

                switch (command.ToLower())
                {
                    case "001":
                        //server welcome
                        setTitle(splitData);
                        break;

                    case "372":
                        //motd
                        break;

                    case "376":
                    case "422":
                        //end of motd
                        status = Status.Connected;
                        joinChannel("#z");

                        break;

                    case "nick":
                        //change nicks in all channels

                        break;

                    case "join":
                        //add nick to channel

                        messageChannel(nick, text, nick + " has joined the channel");
						chan = getChannel(text);
						if (nick.Equals(nickName))
						{
							break;
						}
                        if (chan != null)
                        {
                            chan.AddToUserList(nick);
                        }
                        break;


                    case "part":
                        //remove nick from channel
                        messageChannel(nick, args, nick + " has left the channel");
						chan = getChannel(args);
                        if (chan != null)
                        {
                            chan.RemoveFromUserList(nick);
                        }
                        break;

                    case "quit":
                        //remove nick from all channels

                        break;

                    case "privmsg":
						if (args.StartsWith("#"))
						{
							messageChannel(nick, args, text);
						}
						else
						{
							messageChannel(nick, nick, text);
						}
                        break;

                    case "notice":
                        //send message to channel window
						break;

					case "332":
						argSplit = args.Split(' ');
						chan = getChannel(argSplit[1]);
						if (chan != null)
						{
							chan.printText(text);
						}
						break;  //Topic
					case "333":
						argSplit = args.Split(' ');
						chan = getChannel(argSplit[1]);
						if (chan != null)
						{
							chan.printText("Last Updated by " + argSplit[2] + " at " + (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(double.Parse(argSplit[3])).ToLocalTime().ToString()));
						}
						break;  //Topic Owner and when

                    case "353": //names
                        argSplit = args.Split(' ');
                        chan = getChannel(argSplit[2]);
                        if (chan != null)
                        {
							chan.AddAllToUserList(text);
							chan.printText(text);
                        }
                        break;
                    case "366": //names end
						//fill channel nick list
						argSplit = args.Split(' ');
                        chan = getChannel(argSplit[1]);
                        if (chan != null)
                        {
							chan.printText(text);
                        }
                        break;

                    case "433": //nick in use
                        nickAttempts++;
                        switch (nickAttempts)
                        {
                            case 1:
                                nickName = altNick1;
                                break;
                            case 2:
                                nickName = altNick2;
                                break;
                            default:
                                printText("All nicks tried, Disconnecting");
                                status = Status.Disconnecting;
                                return;
                        }
                        ChangeNickname(nickName);
                        break;
					case "005":
						break;  // Server supported Protocols
					case "405":  
						break;  //Too many Channels
					case "476":
						break;  //Bac Channel Mask
					case "475":
						break;  //Bad channel key
					case "474":  
						break;  //Banned from Channel
					case "374":  
						break;  //Channel mode is
					case "404":  
						break;  //Can't send to channel
					case "471":  
						break;  //Channel is full
					case "482": 
						break;  //Not channel op
					case "473": 
						break;  //Invite only
					case "484": 
						break;  //Is Chan Service
					case "254": 
						break;  // /lusers Response
					case "403": 
						break;  //No Such Channel
					case "442": 
						break;  //Not on Channel
					case "489": 
						break;  //Secure only chan
					case "441": 
						break;  //User not in chan
					case "319": 
						break;  //Whois User common channels
					case "335": 
						break;  //Whois bot
					case "308": 
						break;  //whois admin
					case "311": 
						break;  //Whois User info
					case "431": 
						break;  //No nickname given (/whois /whowas /nick)
					case "401": 
						break;  //No such nick
					case "412": 
						break;  //No text to send
					case "451": 
						break;  //Not registered
					case "402": 
						break;  //Not such server

                    default:
                        printText(line);
                        break;
                }
            }
        }

        private void messageChannel(string nick, string chan, string text)
        {
            if (getChannel(chan) != null)
            {
				if (text.StartsWith(A))
				{
					getChannel(chan).printText("* " + nick + " " + text.Substring(0, text.Length - 0));
				}
				else
					getChannel(chan).printText(nick + ": " + text);
            }
            else
            {

				if (text.StartsWith(A))
				{
					this.printText("* " + nick + " " + text.Substring(7, text.Length - 8));
				}
                this.printText(nick + ": " + text);
            }
        }

        public ChannelWindow getChannel(string chan)
        {
            if (this.node.Nodes.ContainsKey(chan))
            {
                return (ChannelWindow)this.node.Nodes[chan].Tag;
            }
            else return null;
        }

        private void setTitle(string[] splitData)
        {
            this.name = splitData[0].TrimStart(':');
            this.node.Name = this.node.Text = this.address = this.name;
            setTitle();
        }

        private void setTitle()
        {
            this.Text = this.nickName + " on " + this.address;
        }
    }
}
