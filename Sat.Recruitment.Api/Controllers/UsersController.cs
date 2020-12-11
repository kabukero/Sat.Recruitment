using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models;
using Sat.Recruitment.Application.ViewModels;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public partial class UsersController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly ILogger<UsersController> logger;

		public UsersController(IUserService userService, ILogger<UsersController> logger)
		{
			this.userService = userService;
			this.logger = logger;
		}

		[HttpPost]
		[Route("/create-user")]
		public async Task<Result> CreateUser(UserViewModel userViewModel)
		{
			var errors = "";
			var result = new Result();

			if(errors != null && errors != "")
			{
				result.IsSuccess = false;
				result.Errors = errors;
			}

			try
			{
				await userService.CreateUser(userViewModel);
				logger.LogInformation("User Created");
				result.IsSuccess = true;
				result.Errors = "User Created";
			}
			catch(UserServiceException ex)
			{
				logger.LogInformation("The user is duplicated");
				result.IsSuccess = false;
				result.Errors = ex.Message;
			}

			return result;
		}
	}
}
