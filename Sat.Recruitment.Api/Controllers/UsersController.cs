using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.ViewModels;
using Sat.Recruitment.Application.Models;
using System;
using System.Collections.Generic;
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

			ValidateErrors(userViewModel.Name, userViewModel.Email, userViewModel.Address, userViewModel.Phone, ref errors);

			if(errors != null && errors != "")
				return new Result()
				{
					IsSuccess = false,
					Errors = errors
				};

			UserViewModel currentUserViewModel = userService.GetUsers();

			try
			{
				var isDuplicated = false;
				//foreach(var user in _users)
				//{
				//	if(user.Email == newUser.Email
				//		||
				//		user.Phone == newUser.Phone)
				//	{
				//		isDuplicated = true;
				//	}
				//	else if(user.Name == newUser.Name)
				//	{
				//		if(user.Address == newUser.Address)
				//		{
				//			isDuplicated = true;
				//			throw new Exception("User is duplicated");
				//		}

				//	}
				//}

				if(!isDuplicated)
				{
					Debug.WriteLine("User Created");

					return new Result()
					{
						IsSuccess = true,
						Errors = "User Created"
					};
				}
				else
				{
					Debug.WriteLine("The user is duplicated");

					return new Result()
					{
						IsSuccess = false,
						Errors = "The user is duplicated"
					};
				}
			}
			catch
			{
				Debug.WriteLine("The user is duplicated");
				return new Result()
				{
					IsSuccess = false,
					Errors = "The user is duplicated"
				};
			}

			return new Result()
			{
				IsSuccess = true,
				Errors = "User Created"
			};
		}

		//Validate errors
		private void ValidateErrors(string name, string email, string address, string phone, ref string errors)
		{
			if(name == null)
				//Validate if Name is null
				errors = "The name is required";
			if(email == null)
				//Validate if Email is null
				errors = errors + " The email is required";
			if(address == null)
				//Validate if Address is null
				errors = errors + " The address is required";
			if(phone == null)
				//Validate if Phone is null
				errors = errors + " The phone is required";
		}
	}
}
