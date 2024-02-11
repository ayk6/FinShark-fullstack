using FinSharkAPI.DTO.Comment;
using FinSharkAPI.Extensions;
using FinSharkAPI.Helpers;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinSharkAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;
		private readonly UserManager<User> _userManager;
        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
			_commentService = commentService;
			_userManager = userManager;
        }

        [HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] CommentQueryObject commentQueryObject)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var commentDtos = await _commentService.GetAllCommentsAsync(commentQueryObject);
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

		[HttpPost("{symbol:alpha}")]
		public async Task<IActionResult> Create([FromRoute] string symbol, CreateCommentDto createCommentDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var username = User.GetUserName();
			var user = await _userManager.FindByNameAsync(username);
			var commentDto = await _commentService.CreateCommentAsync(createCommentDto, symbol, user.Id);
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
