using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Models;

namespace FinSharkAPI.Services.Contracts
{
	public interface IPortfolioService
	{
		Task<IEnumerable<StockDto>> GetUserPortfolioAsync(User user);
		Task<Portfolio> CreateAsync(User user, StockDto stockDto);
		Task<Portfolio> DeleteAsync(User user, string symbol);
	}
}
