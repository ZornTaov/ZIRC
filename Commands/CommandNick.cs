using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	class CommandNick : CommandBase
	{
		public override string Name()
		{
			return "nick";
		}
		public override bool Do(ServerWindow window, string channel, string[] args)
		{
			if (!base.Do(window, channel, args))
			{
				return false;
			}

			window.ChangeNickname(args[0]);
			return true;
		}
		public override string Syntax()
		{
			return "nick <name>";
		}
		public override string Help()
		{
			return "Changes your nick on current selected server.";
		}
		public override int MinLength()
		{
			return 1;
		}
		public override int MaxLength()
		{
			return 1;
		}
	}
}
