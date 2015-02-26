using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIRC.Commands
{
	public abstract class CommandBase
	{
		public virtual bool Do(ServerWindow window, params object[] args)
		{
			if (args.Length < this.MinLength() || args.Length > this.MaxLength())
			{
				this.ErrorLength(window, args.Length < this.MinLength());
				return false;
			}
			return true;
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
		public virtual void ErrorLength(ChatWindow window, bool small)
		{
			window.printText("Error: "+ (small ? "not enough arguments." : "too many arguments" ) );
		}
	}
}
