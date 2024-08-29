
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public interface IPriorityRepository
    {
        Task<IEnumerable<Priority>> GetAllPrioritiesAsync();
        Task<Priority> GetPriorityByIdAsync(int id);
        Task AddPriorityAsync(Priority priority);
        Task UpdatePriorityAsync(Priority priority);
        Task DeletePriorityAsync(int id);
    }
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public PriorityRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Priority>> GetAllPrioritiesAsync()
        {
            return await _context.Priorities.ToListAsync();
        }

        public async Task<Priority> GetPriorityByIdAsync(int id)
        {
            return await _context.Priorities.FindAsync(id);
        }

        public async Task AddPriorityAsync(Priority priority)
        {
            if (priority == null)
                throw new ArgumentNullException(nameof(priority));

            _context.Priorities.Add(priority);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePriorityAsync(Priority priority)
        {
            if (priority == null)
                throw new ArgumentNullException(nameof(priority));

            _context.Priorities.Update(priority);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePriorityAsync(int id)
        {
            var priority = await _context.Priorities.FindAsync(id);
            if (priority == null)
                throw new KeyNotFoundException("Priority not found.");

            _context.Priorities.Remove(priority);
            await _context.SaveChangesAsync();
        }
    }
}
