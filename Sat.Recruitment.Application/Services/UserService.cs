using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Mappings;
using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task CreateUser(UserViewModel userViewModel)
		{
			if(await UserDuplicated(userViewModel))
				throw new UserServiceException("The user is duplicated");
			await userRepository.CreateUser(UserMapper.ToUser(userViewModel));
		}

		public async Task<UserViewModel> GetUsers()
		{
			return new UserViewModel()
			{
				Users = await userRepository.GetUsers()
			};
		}

		private async Task<bool> UserDuplicated(UserViewModel userViewModel)
		{
			var users = await userRepository.GetUsers();
			return users.Any(x => (x.Email == userViewModel.Email || x.Phone == userViewModel.Phone) || (x.Name == userViewModel.Name && x.Address == userViewModel.Address));
		}
	}
}
