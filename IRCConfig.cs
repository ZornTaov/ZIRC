using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace ZIRC
{
    public class IRCConfig
    {
        public IRCConfig()
        {

        }
        public static void WriteServerConnectSettings(ConnectWindow win)
        {
			Properties.QuickConnect.Default.address = win.serverBox.Text;
			Properties.QuickConnect.Default.port = int.Parse(win.portBox.Text);
			Properties.QuickConnect.Default.password = win.passwordBox.Text;
			Properties.QuickConnect.Default.nickName = win.nicknameBox.Text;
			Properties.QuickConnect.Default.userName = win.usernameBox.Text;
			Properties.QuickConnect.Default.realName = win.realnameBox.Text;
			Properties.QuickConnect.Default.altNick1 = win.altNickBox1.Text;
			Properties.QuickConnect.Default.altNick2 = win.altNickBox2.Text;
			Properties.QuickConnect.Default.Save();
        }
    }
}
