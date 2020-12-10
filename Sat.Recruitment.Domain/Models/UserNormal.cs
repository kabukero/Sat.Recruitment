using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
	public class UserNormal : User
	{
		public override decimal GetPercentage()
		{
			if(Money > 10m && Money < 100m)
				return 0.8m;
			if(Money > 100m)
				return 0.12m;
			return 0m;
		}
	}
}
