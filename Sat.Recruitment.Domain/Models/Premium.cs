using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
	public class Premium : User
	{
		public override decimal GetPercentage()
		{
			if(Money > 100m)
				return 2m;
			return 0;
		}
	}
}
