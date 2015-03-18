
namespace ZIRC.Commands
{
	class CommandPart : CommandBase
	{
		public override string Name()
		{
			return "part";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}

			window.PartChannel( args[0], string.Join( " ", args, 1, args.Length - 1 ) );
			return true;
		}
		public override string Syntax()
		{
			return "part <channel> [reason]";
		}
		public override string Help()
		{
			return "Parts channel on selected server.";
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
