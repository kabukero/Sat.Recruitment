using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Mappings
{
	public class UserMapper : IUserMapper
	{
		private readonly IMoneyFactory moneyFactory;

		public UserMapper(IMoneyFactory moneyFactory)
		{
			this.moneyFactory = moneyFactory;
		}

		public User ToUser(UserViewModel userViewModel)
		{
			var moneyCalculator = moneyFactory.GetMoney(userViewModel.Money, userViewModel.UserType);
			return new User(userViewModel.Name, userViewModel.Email, userViewModel.Address, userViewModel.Phone, userViewModel.UserType, userViewModel.Money, moneyCalculator);
		}
	}
}
