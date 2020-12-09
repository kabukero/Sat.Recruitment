using Sat.Recruitment.Domain.Models;
using System.Collections.Generic;

namespace Sat.Recruitment.Application.ViewModels
{
	public class UserViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string UserType { get; set; }
		public decimal Money { get; set; }

		public IEnumerable<User> Users { get; set; }
	}
}
