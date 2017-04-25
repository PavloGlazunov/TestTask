using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public class ActionAttribute : System.Attribute
	{
		public readonly string Command;

		public ActionAttribute(string command)
		{
			Command = command;
		}
	}
}
