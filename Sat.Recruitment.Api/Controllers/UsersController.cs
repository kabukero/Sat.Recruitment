using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models;
using Sat.Recruitment.Application.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public partial class UsersController : ControllerBase
	{
		private readonly IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpPost]
		[Route("/create-user")]
		public async Task<Result> CreateUser(UserViewModel userViewModel)
		{
			var errors = "";
			var result = new Result();

			ValidateErrors(userViewModel, ref errors);

			if(errors != null && errors != "")
			{
				result.IsSuccess = false;
				result.Errors = errors;
			}

			try
			{
				await userService.CreateUser(userViewModel);
				Debug.WriteLine("User Created");
				result.IsSuccess = true;
				result.Errors = "User Created";
			}
			catch(UserServiceException ex)
			{
				Debug.WriteLine("The user is duplicated");
				result.IsSuccess = false;
				result.Errors = ex.Message;
			}

			return result;
		}

		//Validate errors
		private void ValidateErrors(UserViewModel userViewModel, ref string errors)
		{
			if(userViewModel.Name == null)
				//Validate if Name is null
				errors = "The name is required";
			if(userViewModel.Email == null)
				//Validate if Email is null
				errors = errors + " The email is required";
			if(userViewModel.Address == null)
				//Validate if Address is null
				errors = errors + " The address is required";
			if(userViewModel.Phone == null)
				//Validate if Phone is null
				errors = errors + " The phone is required";
		}
	}
}
