
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public interface ITicketTypeRepository
    {
        Task<IEnumerable<TicketType>> GetAllTicketTypesAsync();
        Task<TicketType> GetTicketTypeByIdAsync(int id);
        Task AddTicketTypeAsync(TicketType ticketType);
        Task UpdateTicketTypeAsync(TicketType ticketType);
        Task DeleteTicketTypeAsync(int id);
    }
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public TicketTypeRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync()
        {
            return await _context.TicketTypes.ToListAsync();
        }

        public async Task<TicketType> GetTicketTypeByIdAsync(int id)
        {
            return await _context.TicketTypes.FindAsync(id);
        }

        public async Task AddTicketTypeAsync(TicketType ticketType)
        {
            if (ticketType == null)
                throw new ArgumentNullException(nameof(ticketType));

            _context.TicketTypes.Add(ticketType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketTypeAsync(TicketType ticketType)
        {
            if (ticketType == null)
                throw new ArgumentNullException(nameof(ticketType));

            _context.TicketTypes.Update(ticketType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketTypeAsync(int id)
        {
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType == null)
                throw new KeyNotFoundException("TicketType not found.");

            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync();
        }
    }
}



