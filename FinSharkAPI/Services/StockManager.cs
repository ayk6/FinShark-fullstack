using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Helpers;
using FinSharkAPI.Mappers;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinSharkAPI.Services
{
	public class StockManager : IStockService
	{

		private readonly IStockRepository _stockRepository;

		public StockManager(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
		}

		public async Task<IEnumerable<StockDto>> GetAllStocksAsync(QueryObject queryObject)
		{
			var stocks = await _stockRepository.GetAllStocksAsync();

			if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
			{
				stocks = stocks.Where(s => s.CompanyName.Contains(queryObject.CompanyName));
			}
			if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
			{
				stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));
			}
			if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
			{
				if (queryObject.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
				{
					stocks = queryObject.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
				}
			}
			var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

			stocks = stocks.Skip(skipNumber).Take(queryObject.PageSize).ToList();

			return stocks.Select(s => s.toStockDto()).ToList();
		}

		public async Task<StockDto> GetStockByIdAsync(int id)
		{
			var stock = await _stockRepository.GetStockByIdAsync(id);
			return stock != null ? stock.toStockDto() : null;
		}

		public async Task<StockDto> CreateStockAsync(CreateStockDto createStockDto)
		{
			var stock = createStockDto.toStockFromCreateDto();
			var createdStock = await _stockRepository.CreateStockAsync(stock);
			return createdStock.toStockDto();
		}

		public async Task<StockDto> UpdateStockAsync(int id, UpdateStockDto updateStockDto)
		{
			var existingStock = await _stockRepository.GetStockByIdAsync(id);

			if (existingStock == null) return null;

			existingStock = existingStock.UpdateFromDto(updateStockDto);

			var updatedStock = await _stockRepository.UpdateStockAsync(existingStock);
			return updatedStock.toStockDto();
		}

		public async Task DeleteStockAsync(int id)
		{
			var stockToDelete = await _stockRepository.GetStockByIdAsync(id);

			if (stockToDelete != null)
			{
				await _stockRepository.DeleteStockAsync(stockToDelete);
			}
		}

		public async Task<StockDto> GetBySymbolAsync(string symbol)
		{
			var stock = await _stockRepository.GetStockBySymbolAsync(symbol);
			return stock.toStockDto();
		}
	}
}
