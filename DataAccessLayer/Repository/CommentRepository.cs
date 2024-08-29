using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;


namespace DataAccessLayer.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<Comment> GetCommentByIdAsync(int id);
        Task<IEnumerable<Comment>> GetCommentsByTicketIdAsync(int ticketId);
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int id);
    }
    public class CommentRepository : ICommentRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public CommentRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTicketIdAsync(int ticketId)
        {
            return await _context.Comments
                .Where(c => c.TicketId == ticketId)
                .ToListAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found.");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
