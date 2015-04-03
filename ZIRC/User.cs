using System;
using System.Text.RegularExpressions;

namespace ZIRC
{
	public class User
	{
		public static char[] UModes = new char[] { '+', '%', '@', '&', '~' };
		public String nick;
		public String user { get; protected set; }
		public String host { get; protected set; }
		public String hostmask { get; protected set; }
		public string mode { get; set; }

		public User( String nick = "Unknown", String host = "Unknown", String user = "Unknown" )
		{
			this.hostmask = nick + "!" + user + "@" + host;
			this.host = host;
			Match matchMode = IRCRegex.usermode.Match( nick );
			mode = "";
			if ( matchMode.Success )
			{
				mode = matchMode.Value;
				nick = nick.Substring( matchMode.Value.Length );
			}
			this.nick = nick;
			this.user = user;
		}
		public static User Parse( String hostmask )
		{
			Match userMatch = IRCRegex.hostsplit.Match( hostmask );
			if ( userMatch.Success )
			{
				User user = new User();

				user.hostmask = hostmask;
				user.nick = userMatch.Groups["nick"].Value;
				user.user = userMatch.Groups["ident"].Value;
				user.host = userMatch.Groups["host"].Value;

				return user;
			}
			else
			{
				throw new FormatException( "Improper format. Expected full hostmask." );
			}
		}
		public override string ToString()
		{
			return mode + nick;
		}
	}
}
