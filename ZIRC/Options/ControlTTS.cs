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
			foreach ( InstalledVoice voice in
			  ServerWindow.synth.GetInstalledVoices() )
			{
				VoiceInfo info = voice.VoiceInfo;
				voiceBox.Items.Add( info.Name );
				OutputVoiceInfo( info );
			}
			voiceBox.SelectedItem = Properties.Settings.Default.TTSVoice;
		}
		private void voiceBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			var voice = voiceBox.SelectedItem as String;
			if ( voice != null )
			{
				ServerWindow.synth.SelectVoice( voice );
				Properties.Settings.Default.TTSVoice = voice;
			}
		}

		// Display information about a synthesizer voice.
		private static void OutputVoiceInfo( VoiceInfo info )
		{
			Console.WriteLine( "  Name: {0}, culture: {1}, gender: {2}, age: {3}.",
			  info.Name, info.Culture, info.Gender, info.Age );
			Console.WriteLine( "    Description: {0}", info.Description );
		}

		private void TTSEnabler_CheckedChanged( object sender, EventArgs e )
		{

			Properties.Settings.Default.TTSEnabled = TTSEnabler.Checked;
		}
	}
}
