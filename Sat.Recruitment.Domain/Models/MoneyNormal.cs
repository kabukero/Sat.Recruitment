namespace Sat.Recruitment.Domain.Models
{
	public class MoneyNormal : MoneyCalculator
	{
		public MoneyNormal(decimal money) : base(money) { }

		public override decimal GetPercentage()
		{
			if(money > 10m && money < 100m)
				return 0.8m;
			if(money > 100m)
				return 0.12m;
			return 0m;
		}
	}
}
