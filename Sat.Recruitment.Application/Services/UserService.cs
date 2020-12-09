using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.ViewModels;
//using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public void CreateUser(UserViewModel userViewModel)
		{
			userRepository.CreateUser(UserMapper.ToUser(userViewModel));
		}

		public UserViewModel GetUsers()
		{
			return new UserViewModel()
			{
				Users = userRepository.GetUsers()
			};
		}

		public bool UserDuplicated(UserViewModel userViewModel)
		{
			var users = userRepository.GetUsers();

			return true;
		}
	}
}
