using System;
using System.Windows.Forms;

namespace ZIRC.Options
{
	public partial class OptionsWindow : Form
	{
		UserControl _currentControl;
		private MainWindow mainWindow;
		public bool styleChanged = false;
		public OptionsWindow( MainWindow mainWindow )
		{
			InitializeComponent();
			this.mainWindow = mainWindow;
			Options.Nodes["Style"].Tag = typeof( ControlStyle );
			Options.Nodes["TTS"].Tag = typeof( ControlTTS );
		}

		private void Options_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if ( _currentControl != null )
			{

				_currentControl.Controls.Remove( _currentControl );
				_currentControl.Dispose();
			}
			if ( ( (TreeNode)e.Node ).Tag == null )
				return;
			//_currentControl = (UserControl)( (TreeNode)e.Node ).Tag;
			_currentControl = (UserControl)Activator.CreateInstance( (Type)( (TreeNode)e.Node ).Tag );
			( (ZIRCControl)_currentControl ).parentWindow = this;
			OptionsPanal.Controls.Add( _currentControl );
		}

		private void saveSettings()
		{
			if ( styleChanged )
			{
				foreach ( TreeNode node in mainWindow.locationTree.Nodes )
				{
					if ( node.Tag is ChatWindow )
					{
						( (ChatWindow)node.Tag ).chatBox.Font = ( (ChatWindow)node.Tag ).inputText.Font = Properties.Settings.Default.mainFont; // attempt to change font, removes previous bold/underline/colors from the text...
						( (ChatWindow)node.Tag ).setTTSDefaults(); // sets all windows to use new defaults, I'd rather do it like this so that everything gets updated than having th euser restart the program.
					}

				}
			}
			Properties.Settings.Default.Save();
		}

		private void cancelAll()
		{
			Properties.Settings.Default.Reload();
		}

		private void Ok_Click( object sender, EventArgs e )
		{
			this.saveSettings();
			this.Close();
		}

		private void Cancel_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void Apply_Click( object sender, EventArgs e )
		{
			this.saveSettings();
		}

		protected override void OnClosed( EventArgs e )
		{
			this.cancelAll();
			base.OnClosed( e );
		}
	}
}
