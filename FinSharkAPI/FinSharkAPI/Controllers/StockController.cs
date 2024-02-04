using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Helpers;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinSharkAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StockController : ControllerBase
	{
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var stockDtos = await _stockService.GetAllStocksAsync(queryObject);
            return Ok(stockDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var stockDto = await _stockService.GetStockByIdAsync(id);
            if (stockDto == null) return NotFound();
            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createStockDto)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var stockDto = await _stockService.CreateStockAsync(createStockDto);
            return CreatedAtAction(nameof(GetById), new { id = stockDto.Id }, stockDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var stockDto = await _stockService.UpdateStockAsync(id, updateStockDto);
            if (stockDto == null) return NotFound();
            return Ok(stockDto);
        }

        [HttpDelete]
		[Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var stockDto = await _stockService.GetStockByIdAsync(id); 
            if (stockDto == null) return NotFound();
            await _stockService.DeleteStockAsync(id);
            return NoContent();
        }
	}
}
