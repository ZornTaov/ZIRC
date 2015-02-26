using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	class CommandMe : CommandBase
	{
		public override string Name()
		{
			return "me";
		}
		/**
		 *	args = 1:channel, 2: 
		 */
		public override bool Do(ServerWindow window, params object[] args)
		{
			if (!base.Do(window, args))
			{
				return false;
			}
			window.SendRaw("PRIVMSG " + (string)args[0] + " :" + window.A + "ACTION " + (string)args[1] + (args.Length < 2 ? "" : " " + (string)args[2]) + window.A);
			window.getChannel((string)args[0]).printText("* " + window.nickName + " " + (string)args[1] + (args.Length < 2 ? "" : " " + (string)args[2]));
			return true;
		}
		public override string Syntax()
		{
			return this.Name() + " your message";
		}
		public override string Help()
		{
			return "Message a channel or user.";
		}
		public override int MinLength()
		{
			return 1;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
