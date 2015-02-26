using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZIRC
{
    public partial class ConnectWindow : Form
    {
        private MainWindow mainWindow;
        
        public ConnectWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            try
            {
				this.serverBox.Text = Properties.Settings.Default.address;
				this.portBox.Text = Properties.Settings.Default.port.ToString();
				this.passwordBox.Text = Properties.Settings.Default.password;
				this.nicknameBox.Text = Properties.Settings.Default.nickName;
				this.usernameBox.Text = Properties.Settings.Default.userName;
				this.realnameBox.Text = Properties.Settings.Default.realName;
				this.altNickBox1.Text = Properties.Settings.Default.altNick1;
				this.altNickBox2.Text = Properties.Settings.Default.altNick2;
			}
            catch (Exception e )
            {
                Console.WriteLine("BEEP " + e);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            this.mainWindow.newServer(this);
            this.Close();
        }

        private void ConnectWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
