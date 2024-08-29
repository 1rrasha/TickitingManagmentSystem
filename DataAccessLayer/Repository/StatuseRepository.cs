
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public interface IStatuseRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int id);
        Task AddStatusAsync(Status status);
        Task UpdateStatusAsync(Status status);
        Task DeleteStatusAsync(int id);
    }
    public class StatuseRepository : IStatuseRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public StatuseRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _context.Statuses.FindAsync(id);
        }

        public async Task AddStatusAsync(Status status)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(Status status)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            _context.Statuses.Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
                throw new KeyNotFoundException("Status not found.");

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
        }
    }
}

