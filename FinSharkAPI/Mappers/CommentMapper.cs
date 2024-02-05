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
				StockId = commentModel.StockId
			};
		}

		public static Comment toCommentFromCreate(this CreateCommentDto createCommentDto, int stockId)
		{
			return new Comment
			{
				Title = createCommentDto.Title,
				Content = createCommentDto.Content,
				StockId = stockId
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
