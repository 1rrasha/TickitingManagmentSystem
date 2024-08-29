
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsByStatusIdAsync(int statusId);
        Task<IEnumerable<Ticket>> GetTicketsByPriorityIdAsync(int priorityId);
        Task<Ticket> AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByCompanyIdAsync(int companyId);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public TicketRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.AsNoTracking()
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.TicketType)
                .Include(t => t.Service)
                .ThenInclude(s => s.Company)
                .Include(t => t.Comments)
                .Include(t => t.UserTickets)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.TicketType)
                .Include(t => t.Service)
                .ThenInclude(s => s.Company)
                .Include(t => t.Comments)
                .Include(t => t.UserTickets)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatusIdAsync(int statusId)
        {
            return await _context.Tickets
                .Where(t => t.StatusId == statusId)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.TicketType)
                .Include(t => t.Service)
                .ThenInclude(s => s.Company)
                .Include(t => t.Comments)
                .Include(t => t.UserTickets)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByPriorityIdAsync(int priorityId)
        {
            return await _context.Tickets
                .Where(t => t.PriorityId == priorityId)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Include(t => t.Service)
                .ThenInclude(s => s.Company)
                .Include(t => t.Comments)
                .Include(t => t.UserTickets)
                .ToListAsync();
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await GetTicketByIdAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByCompanyIdAsync(int companyId)
        {
            return await _context.Tickets
                .Where(t => t.Service.CompanyId == companyId)
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.TicketType)
                .Include(t => t.Service)
                .ThenInclude(s => s.Company)
                .Include(t => t.Comments)
                .Include(t => t.UserTickets)
                .ToListAsync();
        }
    }
}
