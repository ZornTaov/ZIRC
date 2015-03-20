using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZIRC.Options
{
	public interface ZIRCControl
	{
		OptionsWindow parentWindow { get; set; }
	}
}
