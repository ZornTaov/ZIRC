using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using ZIRC.Commands;

namespace ZIRCExtensions
{
	public static class ZIRCExtensions
	{
		public static string ReplaceAt( this string str, string replace, int index = -1, int length = -1 )
		{
			if ( index < 0 ) { index = 0; }
			if ( length < 0 ) { length = 0; }
			return str.Remove( index, Math.Min( length, str.Length - index ) ).Insert( index, replace );
		}

		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		private static extern IntPtr SendMessage( IntPtr hWnd, int msg, IntPtr wp, IntPtr lp );
		private const int WM_SETREDRAW = 0x0b;

		public static void Suspend( this Control richTextBox )
		{
			SendMessage( richTextBox.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero );
		}

		public static void Resume( this Control richTextBox )
		{
			SendMessage( richTextBox.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero );
			richTextBox.Invalidate();
		}
	}
	public static class ReflectiveEnumerator
	{
		static ReflectiveEnumerator() { }

		public static SortedDictionary<string, CommandBase> GetEnumerableOfType<CommandBase>( params object[] constructorArgs )// where CommandBase : class, IComparable<CommandBase>
		{
			SortedDictionary<string, CommandBase> objects = new SortedDictionary<string, CommandBase>();
			foreach ( Type type in
				Assembly.GetAssembly( typeof( CommandBase ) ).GetTypes()
				.Where( myCommandBaseype => myCommandBaseype.IsClass && !myCommandBaseype.IsAbstract && myCommandBaseype.IsSubclassOf( typeof( CommandBase ) ) ) )
			{
				CommandBase obj = (CommandBase)Activator.CreateInstance( type, constructorArgs );
				objects.Add( obj.ToString(), obj );
			}
			//objects.Sort();
			return objects;
		}
	}
}
