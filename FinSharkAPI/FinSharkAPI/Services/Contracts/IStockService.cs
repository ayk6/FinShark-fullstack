using System.Dynamic;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Helpers;
using FinSharkAPI.Models;

namespace FinSharkAPI.Services.Contracts
{
	public interface IStockService
	{
		Task<IEnumerable<StockDto>> GetAllStocksAsync(QueryObject queryObject);
		Task<StockDto> GetStockByIdAsync(int id);
		Task<StockDto> CreateStockAsync(CreateStockDto createStockDto);
		Task<StockDto> UpdateStockAsync(int id, UpdateStockDto updateStockDto);
		Task DeleteStockAsync(int id);
	}
}
