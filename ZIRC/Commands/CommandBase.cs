
using System;
namespace ZIRC.Commands
{
	public abstract class CommandBase
	{
		public virtual bool Do( ServerWindow window, string channel, string[] args )
		{
			if ( args.Length < this.MinLength() || args.Length > this.MaxLength() )
			{
				this.ErrorLength( window, channel, args.Length, args.Length < this.MinLength() );
				return false;
			}
			return true;
		}
		public CommandBase getCommand()
		{
			return this;
		}
		public override string ToString()
		{
			return Name();
		}
		public abstract string Name();
		public abstract string Syntax();
		public abstract string Help();
		public virtual int MinLength()
		{
			return 0;
		}
		public virtual int MaxLength()
		{
			return int.MaxValue;
		}
		public virtual void ErrorLength( ServerWindow window, string channel, int length, bool small )
		{
			window.getChannel( channel ).printText( "Error: " + Name() + " Args: " + length + ( small ? " Not Enough Arguments." : " Too Many Arguments" ) );
		}
	}
}
