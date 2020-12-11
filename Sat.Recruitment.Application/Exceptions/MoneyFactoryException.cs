using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application.Exceptions
{
	public class MoneyFactoryException : Exception
	{
		public MoneyFactoryException()
		{
		}

		public MoneyFactoryException(string message)
			: base(message)
		{
		}

		public MoneyFactoryException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
