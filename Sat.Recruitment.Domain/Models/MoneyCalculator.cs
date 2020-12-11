namespace Sat.Recruitment.Domain.Models
{
	public abstract class MoneyCalculator
	{
		protected decimal money;
		private decimal percentage;

		public MoneyCalculator(decimal money)
		{
			this.money = money;
			percentage = GetPercentage();
		}

		public abstract decimal GetPercentage();

		private decimal CalculateGif() => money * percentage;

		public decimal CalculateMoney() => money + CalculateGif();

	}
}
