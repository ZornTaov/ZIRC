
namespace ZIRC.Commands
{
	class CommandMe : CommandBase
	{
		public override string Name()
		{
			return "me";
		}
		/**
		 *	args = 0:channel, 1: 
		 */
		public override bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( !base.Do( window, channel, args ) )
			{
				return false;
			}
			window.SendRaw( "PRIVMSG " + channel + " :" + ChatWindow.A + "ACTION " + string.Join( " ", args ) + ChatWindow.A );
			window.getChannel( channel ).printText( "* " + window.nickName + " " + string.Join( " ", args ) );
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
