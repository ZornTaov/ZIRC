using System.Text.RegularExpressions;

namespace ZIRC
{
	public class IRCRegex
	{
		/* public static string NICKNAME = @"[\w\|\-\[\]\{\}\^\\\`]+";

		public static string IDENT = @"(?<ident>[\w\-\.]+)";

		public static string HOST = @"(?<host>[\w\.\:\-]+)";

		public static string FULL_HOST = @"(?<fullhost>(?<nick>" + NICKNAME + @")\!\~?" + IDENT + @"@" + HOST + @")";

		public static string SERVER_HOST = @"(?<serverhost>[\w\.]+)";

		public static string RAW = @"(?<raw>(\d{1,3}+))";

		public static string TYPE = @"(?<type>(PRIVMSG|NOTICE|" + RAW + @")";

		public static string CHANCODES;

		public static string LOCATION = @"(?<location>" + CHANCODES + @".+)";

		public static string MESSAGE = @":(?<message>.+)";

		public static string SERVMODES = @"^:" + SERVER_HOST + @"\s" + RAW + @"\s(?:\S+)\s(?<modes>.*)\s:";

		public static string PREFIX = @"PREFIX=\((?<char>\S+)\)(?<code>\S+)";

		public static string CHANTYPES = @"CHANTYPES=(?<types>\S+)";

		public static string PRIV_MESSAGE = @"^:(?:" + FULL_HOST + @"|" + SERVER_HOST + @")\s" + TYPE + @"\s(?:(?:" + LOCATION + @"\s?)?)" + MESSAGE;

		public static string BASIC = @"^:(?:" + FULL_HOST + @")\s(?<type>)\s" + MESSAGE;

		public static string PART = @"^:(?:" + FULL_HOST + @")\s(PART)\s:" + LOCATION + @"(\s" + MESSAGE + @")?";

		public static string KICK = @"^:(?:" + FULL_HOST + @")\s(KICK)\s" + LOCATION + @"\s" + NICKNAME + @"\s" + MESSAGE;

		public static string NAMES = @"^:(?:" + SERVER_HOST + @")\s" + RAW + @"\s(?:\S+)\s.\s" + LOCATION + @"\s" + MESSAGE; 
  */
		// Regular Expression Data Parsers
		public static Regex coreregx = new Regex( @"^(?::(?<hostmask>\S+)\s)?(?<command>\S+)(?:\s(?!:)(?<args>.+?))?(?:\s:(?<text>.+))?$" );
		public static Regex hostsplit = new Regex( @"(?<nick>[\w\`\|\[\]\{\}\\\-]+)!(?<ident>~?[\w\.]+)@(?<host>[\w\d\.\:\-]+)" );
		public static Regex serverflags = new Regex( @"\b(?:(?<name>\w+)(?:=(?<arg>\S+))?\s?)\b" );
		public static Regex modeevent = new Regex( @"(?<chan>\S+)\s(?<text>.*)" );
		public static Regex usermode = new Regex( @"(?<mode>[+%@&~]*)" );
		public static Regex command = new Regex( @"^(?:\/(?<command>[\S]+)\s?)(?:(?<args>.+))?$" );
		public static Regex color = new Regex( @"((?:\x03)(?<fore>\d{1,2})(,(?<back>\d{1,2})?)?)" );
	}
}
