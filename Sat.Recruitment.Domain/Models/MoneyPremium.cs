namespace Sat.Recruitment.Domain.Models
{
	public class MoneyPremium : MoneyCalculator
	{
		public MoneyPremium(decimal money) : base(money) { }

		public override decimal GetPercentage()
		{
			if(money > 100m)
				return 2m;
			return 0m;
		}
	}
}
