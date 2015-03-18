using System;
using System.Windows.Forms;

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
		public static extern bool LockWindowUpdate( IntPtr hWndLock );

		public static void Suspend1( this Control control )
		{
			LockWindowUpdate( control.Handle );
		}

		public static void Resume1( this Control control )
		{
			LockWindowUpdate( IntPtr.Zero );
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
}
