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
		public override bool Do(ServerWindow window, params object[] args)
		{
			if (!base.Do(window, args))
			{
				return false;
			}
			if (((string)args[2]).Equals(""))
			{
				ErrorLength(window.getChannel((string)args[0]), true);
				return false;
			}
			window.SendRaw("PRIVMSG " + (string)args[1] + " :" + (string)args[2]);
			if (window.getChannel((string)args[1]) != null)
			{
				window.getChannel((string)args[1]).printText(window.nickName + ": " + (string)args[2]);
			}
			else
			{
				window.getChannel((string)args[0]).printText("-> *" + (string)args[1] + "* " + (string)args[2]);
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
			return 3;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
