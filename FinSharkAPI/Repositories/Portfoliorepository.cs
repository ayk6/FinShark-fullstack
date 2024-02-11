using FinSharkAPI.Data;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinSharkAPI.Repositories
{
	public class Portfoliorepository : IPortfolioRepository
	{
		private readonly AppDBContext _context;
        public Portfoliorepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

		public async Task<Portfolio> CreateAsync(Portfolio portfolio)
		{
			await _context.AddAsync(portfolio);
			await _context.SaveChangesAsync();
			return portfolio;
		}

		public async Task<Portfolio> DeleteAsync(User user, string symbol)
		{
			var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(p => p.UserId == user.Id && p.Stock.Symbol.ToLower() == symbol.ToLower());

			if (portfolioModel == null)
			{
				return null;
			}
			_context.Portfolios.Remove(portfolioModel);
			await _context.SaveChangesAsync();
			return portfolioModel;
		}

		public async Task<IEnumerable<Stock>> GetUserPortfolioAsync(User user)
		{
			return await _context.Portfolios.Where(p => p.UserId == user.Id).Select(
				stock => new Stock
				{
					Id = stock.StockId,
					Symbol = stock.Stock.Symbol,
					CompanyName = stock.Stock.CompanyName,
					Purchase = stock.Stock.Purchase,
					LastDiv = stock.Stock.LastDiv,
					Industry = stock.Stock.Industry,
					MarketCap = stock.Stock.MarketCap
				}).ToListAsync();
		}
	}
}
