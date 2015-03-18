using System;
using System.Windows.Forms;

namespace ZIRC
{
	public partial class ConnectWindow : Form
	{
		private MainWindow mainWindow;

		public ConnectWindow( MainWindow mainWindow )
		{
			InitializeComponent();
			this.mainWindow = mainWindow;
			try
			{
				this.serverBox.Text = Properties.QuickConnect.Default.address;
				this.portBox.Text = Properties.QuickConnect.Default.port.ToString();
				this.passwordBox.Text = Properties.QuickConnect.Default.password;
				this.nicknameBox.Text = Properties.QuickConnect.Default.nickName;
				this.usernameBox.Text = Properties.QuickConnect.Default.userName;
				this.realnameBox.Text = Properties.QuickConnect.Default.realName;
				this.altNickBox1.Text = Properties.QuickConnect.Default.altNick1;
				this.altNickBox2.Text = Properties.QuickConnect.Default.altNick2;
			}
			catch ( Exception e )
			{
				Console.WriteLine( "BEEP " + e );
			}
		}

		private void cancelButton_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void connectButton_Click( object sender, EventArgs e )
		{
			this.mainWindow.newServer( this );
			this.Close();
		}

		private void ConnectWindow_Load( object sender, EventArgs e )
		{

		}
	}
}
