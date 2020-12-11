using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		public async Task CreateUser(User user)
		{
			var writer = WriteUserToFile();

			await writer.WriteLineAsync(string.Format("{0},{1},{2},{3},{4}", user.Email, user.Name, user.Address, user.Phone, user.UserType, user.Money));
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			var users = new List<User>();
			var reader = ReadUsersFromFile();

			while(reader.Peek() >= 0)
			{
				var line = await reader.ReadLineAsync();
				users.Add(new User(line.Split(',')[0].ToString(), line.Split(',')[1].ToString(), line.Split(',')[2].ToString(), line.Split(',')[3].ToString(), line.Split(',')[4].ToString(), decimal.Parse(line.Split(',')[5].ToString())));
			}
			reader.Close();

			return users;
		}

		private StreamReader ReadUsersFromFile()
		{
			var path = GetCurrentDir();

			FileStream fileStream = new FileStream(path, FileMode.Open);

			StreamReader reader = new StreamReader(fileStream);

			return reader;
		}

		private StreamWriter WriteUserToFile()
		{
			var path = GetCurrentDir();

			FileStream fileStream = new FileStream(path, FileMode.Append);

			StreamWriter writer = new StreamWriter(fileStream);

			return writer;
		}

		private string GetCurrentDir()
		{
			return Directory.GetCurrentDirectory() + "/Files/Users.txt";
		}
	}
}
