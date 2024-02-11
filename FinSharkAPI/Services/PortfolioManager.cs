using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Mappers;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;

namespace FinSharkAPI.Services
{
	public class PortfolioManager : IPortfolioService
	{
		private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioManager(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

		public async Task<Portfolio> CreateAsync(User user, StockDto stockDto)
		{
			var portfolio = new Portfolio
			{
				StockId = stockDto.Id,
				UserId = user.Id
			};
			var createdPortfolio = await _portfolioRepository.CreateAsync(portfolio);
			return createdPortfolio;
		}

		public async Task<Portfolio> DeleteAsync(User user, string symbol)
		{
			var deletedPortfolio = await _portfolioRepository.DeleteAsync(user, symbol);
			return deletedPortfolio;
		}

		public async Task<IEnumerable<StockDto>> GetUserPortfolioAsync(User user)
		{
			var userStocks = await _portfolioRepository.GetUserPortfolioAsync(user);
			return userStocks.Select(s => s.toStockDto());
		}
	}
}
