using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC
{
	class LuaWindow : ChatWindow
	{
		public LuaWindow(MainWindow mainWindow, string name, bool hasList = false)
			: base(mainWindow, name, hasList)
		{

		}

		public override void parseInput(string text, string channel = "")
		{
			printText("lua> " + text);
			try
			{
				object[] result = mainWindow.state.DoString(text);
				if (result != null) printText("*** " + result.ToString());
			}
			catch (Exception e)
			{
				printText(e.ToString());
			}
		}
	}
}
