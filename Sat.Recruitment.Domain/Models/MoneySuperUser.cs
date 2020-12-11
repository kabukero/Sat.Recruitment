namespace Sat.Recruitment.Domain.Models
{
	public class MoneySuperUser : MoneyCalculator
	{
		public MoneySuperUser(decimal money) : base(money) { }

		public override decimal GetPercentage()
		{
			if(money > 100m)
				return 0.20m;
			return 0m;
		}
	}
}
