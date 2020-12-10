using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Domain.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Sat.Recruitment.Application.Services
{
	public class UserFactory : IUserFactory
	{
		public User GetUser(string type)
		{
			var shapeType = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.FirstOrDefault(t => t.Name.ToLowerInvariant() == type && t.IsClass && !t.IsInterface);

			if(shapeType == null) throw new UserServiceException("No such type");

			return Activator.CreateInstance(shapeType) as User;
		}
	}
}
