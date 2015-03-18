
namespace ZIRC.Commands
{
	class CommandJoin : CommandBase
	{
		public override string Name()
		{
			return "join";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}

			window.joinChannel( args );
			return true;
		}
		public override string Syntax()
		{
			return "join <channel> [password]";
		}
		public override string Help()
		{
			return "Joins channel on selected server.";
		}
		public override int MinLength()
		{
			return 1;
		}
		public override int MaxLength()
		{
			return 2;
		}
	}
}
