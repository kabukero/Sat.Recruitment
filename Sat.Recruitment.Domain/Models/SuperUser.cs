using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
	public class SuperUser : User
	{
		public override decimal GetPercentage()
		{
			if(Money > 100m)
				return 0.20m;
			return 0m;
		}
	}
}
