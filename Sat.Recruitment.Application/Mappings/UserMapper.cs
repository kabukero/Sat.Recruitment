using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Mappings
{
	public class UserMapper : IUserMapper
	{
		private readonly IUserFactory userFactory;

		public UserMapper(IUserFactory userFactory)
		{
			this.userFactory = userFactory;
		}

		public User ToUser(UserViewModel userViewModel)
		{
			var user = userFactory.GetUser(userViewModel.UserType);
			user.Name = userViewModel.Name;
			user.Email = userViewModel.Email;
			user.Address = userViewModel.Address;
			user.Phone = userViewModel.Phone;
			user.UserType = userViewModel.UserType;
			user.Money = user.CalculateMoney();
			return user;
		}
	}
}
