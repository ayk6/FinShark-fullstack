using FinSharkAPI.DTO.Comment;
using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Helpers;
using FinSharkAPI.Models;

namespace FinSharkAPI.Services.Contracts
{
	public interface ICommentService
	{
		Task<IEnumerable<CommentDto>> GetAllCommentsAsync(CommentQueryObject commentQueryObject);
		Task<CommentDto> GetCommentAsync(int id);
		Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, string symbol, string userId);
		Task DeleteCommentAsync(int id);
		Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, int id);
	}
}
