using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ZIRC
{
	class Synth
	{
		internal static SpeechSynthesizer synth = new SpeechSynthesizer();
		internal static bool Enabled = false;
		internal static void init()
		{
			if ( Properties.Settings.Default.TTSVoice != "" ) synth.SelectVoice( Properties.Settings.Default.TTSVoice );
			synth.SetOutputToDefaultAudioDevice();
			Enabled = true;
		}

		internal static void SelectVoice( string voice )
		{
			if ( voice != null )
			{
				Synth.synth.SelectVoice( voice );
				Properties.Settings.Default.TTSVoice = voice;
			}
		}

		// Display information about a synthesizer voice.
		internal static void OutputVoiceInfo( VoiceInfo info )
		{
			Console.WriteLine( "  Name: {0}, culture: {1}, gender: {2}, age: {3}.",
			  info.Name, info.Culture, info.Gender, info.Age );
			Console.WriteLine( "    Description: {0}", info.Description );
		}
	}
}
