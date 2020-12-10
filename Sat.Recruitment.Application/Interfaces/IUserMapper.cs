using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IUserMapper
	{
		User ToUser(UserViewModel userViewModel);
	}
}
