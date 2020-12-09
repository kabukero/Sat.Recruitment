using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Mappings
{
	public static class UserMapper
	{
		public static User ToUser(UserViewModel userViewModel)
		{
			return new User()
			{
				Name = userViewModel.Name,
				Email = userViewModel.Email,
				Address = userViewModel.Address,
				Phone = userViewModel.Phone,
				UserType = userViewModel.UserType,
				Money = userViewModel.Money
			};
		}
	}
}
