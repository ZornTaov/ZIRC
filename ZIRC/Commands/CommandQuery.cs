using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	public class CommandQuery : CommandBase
	{
		public override string Name()
		{
			return "query";
		}
		public override bool Do(ServerWindow window, string channel, string[] args)
		{
			if (!base.Do(window, channel, args))
			{
				return false;
			}
			window.queryUser((string)args[0]);
			return true;
		}
		public override string Syntax()
		{
			return "query <nick>";
		}
		public override string Help()
		{
			return "Opens a Private Message window with the selected user.";
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
