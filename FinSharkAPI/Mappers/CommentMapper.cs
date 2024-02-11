using FinSharkAPI.DTO.Comment;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Models;

namespace FinSharkAPI.Mappers
{
	public static class CommentMapper
	{
		public static CommentDto toCommentDto(this Comment commentModel)
		{
			return new CommentDto
			{
				Id = commentModel.Id,
				Title = commentModel.Title,
				Content = commentModel.Content,
				CreatedOn = commentModel.CreatedOn,
				StockId = commentModel.StockId,
				CreatedBy = commentModel.User.UserName

			};
		}

		public static Comment toCommentFromCreate(this CreateCommentDto createCommentDto, int stockId, string userId)
		{
			return new Comment
			{
				Title = createCommentDto.Title,
				Content = createCommentDto.Content,
				StockId = stockId,
				UserId = userId
			};
		}

		public static Comment UpdateFromDto(this Comment comment, UpdateCommentDto updateCommentDto)
		{
			comment.Title = updateCommentDto.Title;
			comment.Content = updateCommentDto.Content;

			return comment;
		}
	}
}
