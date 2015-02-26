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
            Properties.Settings.Default.address = win.serverBox.Text;
            Properties.Settings.Default.port = int.Parse(win.portBox.Text);
            Properties.Settings.Default.password = win.passwordBox.Text;
            Properties.Settings.Default.nickName = win.nicknameBox.Text;
            Properties.Settings.Default.userName = win.usernameBox.Text;
            Properties.Settings.Default.realName = win.realnameBox.Text;
            Properties.Settings.Default.altNick1 = win.altNickBox1.Text;
            Properties.Settings.Default.altNick2 = win.altNickBox2.Text;
			Properties.Settings.Default.Save();
        }
    }
}
