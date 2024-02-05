using FinSharkAPI.Models;

namespace FinSharkAPI.Repositories.Contracts
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> CreateAsync(Comment commentModel);
        Task DeleteAsync(Comment commentModel);
		Task<Comment?> UpdateAsync(Comment commentModel);
	}
}
