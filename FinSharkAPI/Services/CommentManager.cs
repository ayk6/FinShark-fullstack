using FinSharkAPI.DTO.Comment;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Mappers;
using FinSharkAPI.Repositories;
using FinSharkAPI.Repositories.Contracts;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinSharkAPI.Services
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

		public async Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, int stockId)
		{
			var comment = createCommentDto.toCommentFromCreate(stockId);
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

		public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
		{
			var comments = await _commentRepository.GetAllAsync();
			return comments.Select(c => c.toCommentDto());
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
