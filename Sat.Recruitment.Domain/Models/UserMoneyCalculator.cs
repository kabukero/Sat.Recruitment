using Sat.Recruitment.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
	internal class UserMoneyCalculator
	{
		private static readonly PercentageCalculator[] Percentages = new PercentageCalculator[]
			{
				new PercentageCalculator((t, m) => t == TypesUser.NORMAL && m > 100m, 0.12m),
				new PercentageCalculator((t, m) => t == TypesUser.NORMAL && m > 10m && m < 100m, 0.8m),
				new PercentageCalculator((t, m) => t == TypesUser.SUPER_USER && m >= 0, 0.20m),
				new PercentageCalculator((t, m) => t == TypesUser.PREMIUM && m >= 0, 2m),
				new PercentageCalculator((t, m) => true, 0m)
			};

		public static decimal CalculateMoney(string userType, decimal money)
		{
			var calculator = Percentages.First(t => t.CanApply(userType, money));
			var gif = money * calculator.Percentage;
			money += gif;
			return money;
		}
	}
}
