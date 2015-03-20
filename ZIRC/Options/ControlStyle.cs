using System;
using System.Windows.Forms;

namespace ZIRC.Options
{
	public partial class ControlStyle : UserControl, ZIRCControl
	{
		public OptionsWindow parentWindow { get; set; }
		public ControlStyle()
		{
			InitializeComponent();
		}

		private void selFont_Click( object sender, EventArgs e )
		{
			fontDialog1.Font = Properties.Settings.Default.mainFont;
			DialogResult result = fontDialog1.ShowDialog();
			if ( result == DialogResult.OK )
			{
				Properties.Settings.Default.mainFont = fontDialog1.Font;
				parentWindow.styleChanged = true;
			}
		}
	}
}
