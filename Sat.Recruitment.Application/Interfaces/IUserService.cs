using Sat.Recruitment.Application.ViewModels;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IUserService
	{
		public Task CreateUser(UserViewModel userViewModel);

		public Task<UserViewModel> GetUsers();

	}
}
