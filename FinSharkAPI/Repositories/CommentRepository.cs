using FinSharkAPI.Data;
using FinSharkAPI.Models;
using FinSharkAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinSharkAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDBContext _context;
        public CommentRepository(AppDBContext context)
        {
            _context = context;
        }

		public async Task<Comment?> CreateAsync(Comment comment)
		{
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
			return comment;
		}

		public async Task DeleteAsync(Comment commentModel)
		{
			_context.Comments.Remove(commentModel);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Comment?> UpdateAsync(Comment commentModel)
		{
			_context.Comments.Update(commentModel);
			await _context.SaveChangesAsync();
			return commentModel;
		}
	}
}
