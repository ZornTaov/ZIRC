using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	class CommandCTCP : CommandBase
	{
		public override string Name()
		{
			return "ctcp";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}
			window.SendRaw( "PRIVMSG " + args[0] + " :" + ChatWindow.A + args[1] + ( args.Length > 2 ? " " + string.Join( " ", args, 2, args.Length - 2 ) : "" ) + ChatWindow.A );
			return true;
		}
		public override string Syntax()
		{
			return "ctcp <nick> <command>";
		}
		public override string Help()
		{
			return "Sends a CTCP to the user (LIST PENDING).";
		}
		public override int MinLength()
		{
			return 2;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
