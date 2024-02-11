using FinSharkAPI.DTO.Comment;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Helpers;
using FinSharkAPI.Mappers;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinSharkAPI.Services
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IStockRepository _stockRepository;
        public CommentManager(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
			_stockRepository = stockRepository;
        }

		public async Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, string symbol, string userId)
		{
			var stock = await _stockRepository.GetStockBySymbolAsync(symbol);
			if (stock == null) throw new Exception("stock doesn't exist");
	
			
			var comment = createCommentDto.toCommentFromCreate(stock.Id, userId);
			var createdComment = await _commentRepository.CreateAsync(comment);
			return createdComment.toCommentDto();
		}

		public async Task DeleteCommentAsync(int id)
		{
			var commentToDelete = await _commentRepository.GetByIdAsync(id);
			if (commentToDelete != null)
			{
				await _commentRepository.DeleteAsync(commentToDelete);
			}
		}


		public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync(CommentQueryObject commentQueryObject)
		{
			var comments = await _commentRepository.GetAllAsync();

			if (!string.IsNullOrWhiteSpace(commentQueryObject.Symbol))
			{
				comments = comments.Where(c => c.Stock != null && c.Stock.Symbol == commentQueryObject.Symbol);
			}
			if (commentQueryObject.IsDescending == true)
			{
				comments = comments.OrderByDescending(c => c.CreatedOn);
			}

			return comments
				.Where(c => c != null)
				.Select(c => c.toCommentDto())
				.ToList();
		}

		public async Task<CommentDto> GetCommentAsync(int id)
		{
			var comment = await _commentRepository.GetByIdAsync(id);
			return comment != null ? comment.toCommentDto() : null;
		}

		public async Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, int id)
		{
			var existingComment = await _commentRepository.GetByIdAsync(id);
			if (existingComment == null) return null;
			existingComment = existingComment.UpdateFromDto(updateCommentDto);
			var updatedComment = await _commentRepository.UpdateAsync(existingComment);
			return updatedComment.toCommentDto();
			
		}
	}
}
