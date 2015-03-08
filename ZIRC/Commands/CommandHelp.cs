using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	class CommandHelp : CommandBase
	{
		public override string Name()
		{
			return "help";
		}
		public override bool Do(ServerWindow window, string channel, string[] args)
		{
			if (!base.Do(window, channel, args))
			{
				return false;
			}
			ChatWindow wind = window;
			if (!channel.Equals("") && window.getChannel(channel) != null)
			{
				wind = window.getChannel(channel);	
			}
			if(args.Length == 1)
			{
				if (MainWindow.commands.ContainsKey(args[0]))
				{
					wind.printText("*** " + ((CommandBase)MainWindow.commands[args[0]]).Syntax());
					wind.printText("*** " + ((CommandBase)MainWindow.commands[args[0]]).Help());
				}
				else
				{
					wind.printText("Command " + args[0] + " not found!");
				}
			}
			else
			{
				string text = "*** ";
				int i = 0;
				foreach (CommandBase com in MainWindow.commands.Values)
				{
					text = string.Format("{0}| {1,-10}", text, com.Name());
					if (i % 5 == 4)
					{
						wind.printText(text + " |");
						text = "*** ";
					}
					i++;
				}
				if (!text.Equals("*** "))wind.printText(text + " |");
			}
			
			return true;
		}
		public override string Syntax()
		{
			return "help [command]";
		}
		public override string Help()
		{
			return "Displays command usage.";
		}
		public override int MinLength()
		{
			return 0;
		}
		public override int MaxLength()
		{
			return 1;
		}
	}
}
