
namespace ZIRC.Commands
{
	public class CommandConnect : CommandBase
	{
		public override string Name()
		{
			return "connect";
		}
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}

			if ( window.status == ServerWindow.Status.Disconnected )
			{
				window.connect();
			}
			return true;
		}
		public override string Syntax()
		{
			return "connect";
		}
		public override string Help()
		{
			return "Reconnects to current selected server.";
		}
		public override int MinLength()
		{
			return 0;
		}
		public override int MaxLength()
		{
			return 0;
		}
	}
}
