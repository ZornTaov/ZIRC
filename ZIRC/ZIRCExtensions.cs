using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRCExtensions
{
	public static class ZIRCExtensions
	{
		public static string ReplaceAt(this string str, string replace, int index = -1, int length = -1)
		{
			if (index < 0) { index = 0; }
			if (length < 0) { length = 0; }
			return str.Remove(index, Math.Min(length, str.Length - index)).Insert(index, replace);
		}
	}
}
