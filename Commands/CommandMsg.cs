using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	public class CommandMsg : CommandBase
	{
		public override string Name()
		{
			return "msg";
		}
		public override bool Do(ServerWindow window, string channel, string[] args)
		{
			if (!base.Do(window, channel,args))
			{
				return false;
			}
			window.SendRaw("PRIVMSG " + (string)args[0] + " :" + string.Join(" ", args, 1, args.Length - 1));
			if (window.getChannel((string)args[0]) != null)
			{
				window.getChannel((string)args[0]).printText(window.nickName + ": " + string.Join(" ", args, 1, args.Length - 1));
			}
			else
			{
				window.printText("-> *" + (string)args[0] + "* " + string.Join(" ", args, 1, args.Length - 1));
			}
			return true;
		}
		public override string Syntax()
		{
			return this.Name() + " <#channel|nickname> your message";
		}
		public override string Help()
		{
			return "Message a channel or user.";
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
