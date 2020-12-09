using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.ViewModels;
using Xunit;

namespace Sat.Recruitment.Test
{
	[CollectionDefinition("Tests", DisableParallelization = true)]
	public class UnitTest1
	{
		private readonly UsersController userController;

		public UnitTest1(UsersController userController)
		{
			this.userController = userController;
		}

		[Fact]
		public void Test1()
		{
			var result = userController.CreateUser(new UserViewModel() { Name = "Mike", Email = "mike@gmail.com", Address = "Av. Juan G", Phone = "+349 1122354215", UserType = "Normal", Money = 124m }).Result;
			Assert.Equal(true, result.IsSuccess);
			Assert.Equal("User Created", result.Errors);
		}

		[Fact]
		public void Test2()
		{
			var result = userController.CreateUser(new UserViewModel() { Name = "Agustina", Email = "Agustina@gmail.com", Address = "Av. Juan G", Phone = "+349 1122354215", UserType = "Normal", Money = 124m }).Result;
			Assert.Equal(false, result.IsSuccess);
			Assert.Equal("The user is duplicated", result.Errors);
		}
	}
}
