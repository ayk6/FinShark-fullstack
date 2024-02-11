using FinSharkAPI.Extensions;
using FinSharkAPI.Models;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinSharkAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PortfolioController : ControllerBase
	{
        private readonly UserManager<User> _userManager;
		private readonly IPortfolioService _portfolioService;
        private readonly IStockService _stockService;
        public PortfolioController(UserManager<User> userManager,IPortfolioService portfolioService, IStockService stockService)
        {
            _userManager = userManager;
            _portfolioService = portfolioService;
            _stockService = stockService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var userName = User.GetUserName();
            var user = await _userManager.FindByNameAsync(userName);
            var userPortfolio = await _portfolioService.GetUserPortfolioAsync(user);
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(string symbol)
        {
            var username = User.GetUserName();
            var user = await _userManager.FindByNameAsync(username);
            var stockDto = await _stockService.GetBySymbolAsync(symbol);

            if (stockDto == null) return BadRequest("stock not found");

            var userPortfolio = await _portfolioService.GetUserPortfolioAsync(user);
            if (userPortfolio.Any(s => s.Symbol.ToLower() == symbol.ToLower())) {
                return BadRequest("cannot add same stock");
            }

            var portfolioModel = await _portfolioService.CreateAsync(user, stockDto);
            
            if (portfolioModel == null) return StatusCode(500,"could not created");
            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(string symbol)
        {
			var username = User.GetUserName();
			var user = await _userManager.FindByNameAsync(username);
			var userPortfolio = await _portfolioService.GetUserPortfolioAsync(user);

            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();
            if (filteredStock.Count() == 1)
            {
                await _portfolioService.DeleteAsync(user, symbol);
            } else return BadRequest("stock is not in portfolio");
            return Ok();
		}


    }
}
