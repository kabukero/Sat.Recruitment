using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IUserFactory
	{
		User GetUser(string type);
	}
}
