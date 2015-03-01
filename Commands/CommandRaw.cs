
namespace ZIRC.Commands
{
	public class CommandRaw : CommandBase
	{
		public override string Name()
		{
			return "raw";
		}
		public override bool Do(ServerWindow window, string channel, string[] args)
		{
			if (!base.Do(window, channel, args))
			{
				return false;
			}
			window.SendRaw(string.Join(" ",args));
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
			return 2;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
