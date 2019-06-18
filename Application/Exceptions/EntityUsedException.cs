using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
	public class EntityUsedException : Exception
	{
		public EntityUsedException(string message) : base(message)
		{
		}
	}
}
