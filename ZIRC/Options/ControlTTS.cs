using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace ZIRC.Options
{
	public partial class ControlTTS : UserControl, ZIRCControl
	{
		public OptionsWindow parentWindow { get; set; }
		public ControlTTS()
		{
			InitializeComponent();
			PopulateInstalledVoices();
			TTSEnabler.Checked = Properties.Settings.Default.TTSEnabled;
		}
		private void PopulateInstalledVoices()
		{
			if ( Synth.synth.GetInstalledVoices().Count == 0 )
			{
				this.TTSEnabler.Enabled = false;
				this.voiceBox.Enabled = false;
				this.trackBar1.Enabled = false;
				this.trackBar2.Enabled = false;
			}
			else
			{
				foreach ( InstalledVoice voice in
				  Synth.synth.GetInstalledVoices() )
				{
					VoiceInfo info = voice.VoiceInfo;
					voiceBox.Items.Add( info.Name );
					//OutputVoiceInfo( info );
				}
				voiceBox.SelectedItem = Properties.Settings.Default.TTSVoice;
			}
		}
		private void voiceBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			Synth.SelectVoice( voiceBox.SelectedItem as String );
		}

		private void TTSEnabler_CheckedChanged( object sender, EventArgs e )
		{
			Properties.Settings.Default.TTSEnabled = TTSEnabler.Checked;
		}
	}
}
