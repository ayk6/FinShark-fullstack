using FinSharkAPI.DTO.Comment;
using FinSharkAPI.DTO.Stock;

namespace FinSharkAPI.Services.Contracts
{
	public interface ICommentService
	{
		Task<IEnumerable<CommentDto>> GetAllCommentsAsync();
		Task<CommentDto> GetCommentAsync(int id);
		Task<CommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, int stockId);
		Task DeleteCommentAsync(int id);
		Task<CommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, int id);
	}
}
