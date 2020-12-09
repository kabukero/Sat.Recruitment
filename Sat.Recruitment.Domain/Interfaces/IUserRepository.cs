using Sat.Recruitment.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces
{
	public interface IUserRepository
	{
		public Task CreateUser(User user);

		public Task<IEnumerable<User>> GetUsers();
	}
}
