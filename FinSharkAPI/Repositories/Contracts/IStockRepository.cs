using FinSharkAPI.Helpers;
using FinSharkAPI.Models;

namespace FinSharkAPI.Repositories.Contracts
{
	public interface IStockRepository
	{
		Task<IEnumerable<Stock>> GetAllStocksAsync();
		Task<Stock> GetStockByIdAsync(int id);
		Task<Stock> GetStockBySymbolAsync(string symbol);
		Task<Stock> CreateStockAsync(Stock stock);
		Task<Stock> UpdateStockAsync(Stock stock);
		Task DeleteStockAsync(Stock stock);
		Task<Boolean> isStockExists(int id);
	}
}
