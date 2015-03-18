
namespace ZIRC.Commands
{
	public class CommandExample : CommandBase
	{
		public override string Name()
		{
			return "example";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}

			window.getChannel( channel ).printText( "This is an example command that prints to the channel you're on!" );
			return true;
		}
		public override string Syntax()
		{
			return "example";
		}
		public override string Help()
		{
			return "This is an example command that prints to the channel you're on!";
		}
		public override int MinLength()
		{
			return 0;
		}
		public override int MaxLength()
		{
			return int.MaxValue;
		}
	}
}
