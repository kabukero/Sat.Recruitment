using Sat.Recruitment.Application.ViewModels;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IUserService
	{
		public void CreateUser(UserViewModel userViewModel);

		public UserViewModel GetUsers();

		public bool UserDuplicated(UserViewModel userViewModel);
	}
}
