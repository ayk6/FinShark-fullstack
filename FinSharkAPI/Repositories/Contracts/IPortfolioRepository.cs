using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Models;

namespace FinSharkAPI.Repositories.Contracts
{
	public interface IPortfolioRepository
	{
		Task<IEnumerable<Stock>> GetUserPortfolioAsync(User user);
		Task<Portfolio> CreateAsync(Portfolio portfolio);
		Task<Portfolio> DeleteAsync(User user, string symbol);

	}
}
