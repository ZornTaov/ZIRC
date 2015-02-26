using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	class CommandExample : CommandBase
	{
		public override string Name()
		{
			return "example";
		}
		public override bool Do(ServerWindow window, params object[] args)
		{
			if (!base.Do(window, args))
			{
				return false;
			}

			return true;
		}
		public override string Syntax()
		{
			return "";
		}
		public override string Help()
		{
			return "";
		}
		public override int MinLength()
		{
			return 3;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
