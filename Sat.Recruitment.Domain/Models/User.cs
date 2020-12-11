using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Domain.Models
{
	public class User
	{
		[Required(ErrorMessage = "The name is required")]
		public string Name { get; private set; }
		[Required(ErrorMessage = "The email is required")]
		public string Email { get; private set; }
		[Required(ErrorMessage = "The address is required")]
		public string Address { get; private set; }
		[Required(ErrorMessage = "The phone is required")]
		public string Phone { get; set; }
		public string UserType { get; set; }
		public decimal Money { get; private set; }

		private MoneyCalculator _moneyCalculator;

		public User(string name, string email, string address, string phone, string userType, decimal money)
		{
			Name = name;
			Email = email;
			Address = address;
			Phone = phone;
			UserType = userType;
			Money = money;
		}

		public User(string name, string email, string address, string phone, string userType, decimal money, MoneyCalculator moneyCalculator)
		{
			Name = name;
			Email = email;
			Address = address;
			Phone = phone;
			UserType = userType;
			_moneyCalculator = moneyCalculator;
			Money = _moneyCalculator.CalculateMoney();
		}
	}
}
