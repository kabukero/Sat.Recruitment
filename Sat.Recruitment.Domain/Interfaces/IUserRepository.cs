using Sat.Recruitment.Domain.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.Domain.Interfaces
{
	public interface IUserRepository
	{
		public void CreateUser(User user);

		public IEnumerable<User> GetUsers();
	}
}
