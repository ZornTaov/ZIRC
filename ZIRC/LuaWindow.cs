using System;

namespace ZIRC
{
	class LuaWindow : ChatWindow
	{
		public LuaWindow( MainWindow mainWindow, string name, bool hasList = false )
			: base( mainWindow, name, hasList )
		{

		}

		public override void parseInput( string text, string channel = "" )
		{
			printText( "lua> " + text );
			try
			{
				object[] result = mainWindow.state.DoString( text );
				if ( result != null )
				{
					string line = "[" + DateTime.Now.ToShortTimeString() + "] *** ";
					foreach ( object item in result )
					{
						line += ( item == null ? "nil" : item.ToString() ) + "\t";
					}
					printText( line );
				}
			}
			catch ( Exception e )
			{
				printText( e.ToString() );
			}
		}
	}
}
