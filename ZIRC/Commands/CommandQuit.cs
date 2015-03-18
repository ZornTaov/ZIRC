
namespace ZIRC.Commands
{
	public class CommandQuit : CommandBase
	{
		public override string Name()
		{
			return "quit";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}

			window.status = ServerWindow.Status.Disconnecting;
			window.SendRaw( "QUIT " + string.Join( " ", args ) );
			return true;
		}
		public override string Syntax()
		{
			return "quit [reason]";
		}
		public override string Help()
		{
			return "Quits the current selected server.";
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
