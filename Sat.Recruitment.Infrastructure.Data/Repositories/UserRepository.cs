using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Infrastructure.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		public void CreateUser(User user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetUsers()
		{
			var users = new List<User>();
			var reader = ReadUsersFromFile();

			while(reader.Peek() >= 0)
			{
				var line = reader.ReadLineAsync().Result;
				var user = new User
				{
					Name = line.Split(',')[0].ToString(),
					Email = line.Split(',')[1].ToString(),
					Phone = line.Split(',')[2].ToString(),
					Address = line.Split(',')[3].ToString(),
					UserType = line.Split(',')[4].ToString(),
					Money = decimal.Parse(line.Split(',')[5].ToString()),
				};
				users.Add(user);
			}
			reader.Close();

			return users;
		}

		private StreamReader ReadUsersFromFile()
		{
			var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

			FileStream fileStream = new FileStream(path, FileMode.Open);

			StreamReader reader = new StreamReader(fileStream);
			return reader;
		}
	}
}
