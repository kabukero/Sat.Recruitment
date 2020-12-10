using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;
		private readonly IUserMapper userMapper;

		public UserService(IUserRepository userRepository, IUserMapper userMapper)
		{
			this.userRepository = userRepository;
			this.userMapper = userMapper;
		}

		public async Task CreateUser(UserViewModel userViewModel)
		{
			if(await UserDuplicated(userViewModel))
				throw new UserServiceException("The user is duplicated");
			await userRepository.CreateUser(userMapper.ToUser(userViewModel));
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
