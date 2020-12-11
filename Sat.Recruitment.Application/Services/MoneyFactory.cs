using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Domain.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Sat.Recruitment.Application.Services
{
	public class MoneyFactory : IMoneyFactory
	{
		public MoneyCalculator GetMoney(decimal money, string type)
		{
			var moneyType = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.FirstOrDefault(t => t.Name.ToLowerInvariant() == string.Format("Money{0}", type) && t.IsClass && !t.IsInterface);

			Object[] args = { money, type };

			if(moneyType == null) throw new MoneyFactoryException("No such type");

			return Activator.CreateInstance(moneyType, args) as MoneyCalculator;
		}
	}
}
