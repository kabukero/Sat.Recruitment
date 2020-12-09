using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
	internal class PercentageCalculator
	{
		public Func<string, decimal, bool> CanApply { get; set; }
		public decimal Percentage { get; set; }

		public PercentageCalculator(Func<string, decimal, bool> canApply, decimal percentage)
		{
			CanApply = canApply;
			Percentage = percentage;
		}
	}
}
