using Sat.Recruitment.Domain.Models;

namespace Sat.Recruitment.Application.Interfaces
{
	public interface IMoneyFactory
	{
		MoneyCalculator GetMoney(decimal money, string type);
	}
}
