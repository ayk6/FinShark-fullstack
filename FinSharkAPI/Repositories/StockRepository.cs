using FinSharkAPI.Data;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinSharkAPI.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly AppDBContext _context;

		public StockRepository(AppDBContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Stock>> GetAllStocksAsync()
		{
			return await _context.Stocks.Include(c=> c.Comments).ToListAsync();
		}

		public async Task<Stock> CreateStockAsync(Stock stock)
		{
			await _context.Stocks.AddAsync(stock);
			await _context.SaveChangesAsync();
			return stock;
		}

		public async Task DeleteStockAsync(Stock stock)
		{
			_context.Stocks.Remove(stock);
			await _context.SaveChangesAsync();
		}

		public async Task<Stock> GetStockByIdAsync(int id)
		{
			return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Stock> UpdateStockAsync(Stock stock)
		{
			_context.Stocks.Update(stock);
			await _context.SaveChangesAsync();
			return stock;
		}

		public Task<bool> isStockExists(int id)
		{
			return _context.Stocks.AnyAsync(s => s.Id == id);
		}
	}
}
