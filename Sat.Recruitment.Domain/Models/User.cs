namespace Sat.Recruitment.Domain.Models
{
	public abstract class User
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string UserType { get; set; }
		public decimal Money { get; set; }

		private decimal Percentage;

		public User()
		{
			Percentage = GetPercentage();
		}

		public abstract decimal GetPercentage();

		private decimal CalculateGif() => Money * Percentage;

		public decimal CalculateMoney() => Money + CalculateGif();

	}
}
