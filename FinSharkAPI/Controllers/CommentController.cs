using FinSharkAPI.DTO.Comment;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinSharkAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;
		private readonly IStockRepository _stockRepository;
        public CommentController(ICommentService commentService, IStockRepository stockRepository)
        {
			_commentService = commentService;
			_stockRepository = stockRepository;
        }

        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var commentDtos = await _commentService.GetAllCommentsAsync();
			return Ok(commentDtos);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var commentDto = await _commentService.GetCommentAsync(id);
			if (commentDto == null) return NotFound();
			return Ok(commentDto);
		}

		[HttpPost("{stockId:int}")]
		public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto createCommentDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!await _stockRepository.isStockExists(stockId)) return BadRequest("Stock doesn't exist");
			var commentDto = await _commentService.CreateCommentAsync(createCommentDto, stockId);
			return CreatedAtAction(nameof(GetById), new { id = commentDto.Id }, commentDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var commentDto = await _commentService.GetCommentAsync(id);
			if (commentDto == null) return NotFound();
			await _commentService.DeleteCommentAsync(id);
			return NoContent();
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var commentDto = await _commentService.UpdateCommentAsync(updateCommentDto, id);
			if (commentDto == null) return NotFound();
			return Ok(commentDto);
		}
	}
}
