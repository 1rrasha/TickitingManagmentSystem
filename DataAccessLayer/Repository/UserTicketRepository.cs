
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    public interface IUserTicketRepository
    {
        Task<UserTicket> GetUserTicketByIdAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<UserTicket>> GetAllUserTicketsAsync();
        Task AddUserTicketAsync(UserTicket userTicket);
        Task UpdateUserTicketAsync(UserTicket userTicket);
        Task DeleteUserTicketAsync(int id);
        Task<IEnumerable<UserTicket>> GetUserTicketsByUserIdAsync(int userId);
        Task<IEnumerable<UserTicket>> GetUserTicketsByTicketIdAsync(int ticketId);
    }

    public class UserTicketRepository : IUserTicketRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public UserTicketRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<UserTicket> GetUserTicketByIdAsync(int id) =>
       await _context.UserTickets
           .Include(ut => ut.User)
           .Include(ut => ut.Ticket)
               .ThenInclude(t => t.Status)
           .Include(ut => ut.Ticket)
               .ThenInclude(t => t.Priority)
           .Include(ut => ut.Ticket)
               .ThenInclude(t => t.Service)
                   .ThenInclude(s => s.Company)
           .Include(ut => ut.Ticket)
               .ThenInclude(t => t.TicketType)
           .Include(ut => ut.Ticket)
               .ThenInclude(t => t.Comments)
           .SingleOrDefaultAsync(ut => ut.Id == id);


        public async Task<User> GetUserByIdAsync(int id) =>
            await _context.Users
                .Include(u => u.UserTickets)
                    .ThenInclude(ut => ut.Ticket)
                .SingleOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<UserTicket>> GetAllUserTicketsAsync() =>
            await _context.UserTickets
                .Include(ut => ut.User)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Status)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Priority)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Service)
                        .ThenInclude(s => s.Company)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.TicketType)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Comments)
                .ToListAsync();

        public async Task AddUserTicketAsync(UserTicket userTicket)
        {
            await _context.UserTickets.AddAsync(userTicket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserTicketAsync(UserTicket userTicket)
        {
            _context.UserTickets.Update(userTicket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTicketAsync(int id)
        {
            var userTicket = await _context.UserTickets
                .SingleOrDefaultAsync(ut => ut.Id == id);

            if (userTicket != null)
            {
                _context.UserTickets.Remove(userTicket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserTicket>> GetUserTicketsByUserIdAsync(int userId) =>
            await _context.UserTickets
                .Where(ut => ut.UserId == userId)
                .Include(ut => ut.User)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Status)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Priority)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Service)
                        .ThenInclude(s => s.Company)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.TicketType)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Comments)
                .ToListAsync();

        public async Task<IEnumerable<UserTicket>> GetUserTicketsByTicketIdAsync(int ticketId) =>
            await _context.UserTickets
                .Where(ut => ut.TicketId == ticketId)
                .Include(ut => ut.User)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Status)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Priority)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Service)
                        .ThenInclude(s => s.Company)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.TicketType)
                .Include(ut => ut.Ticket)
                    .ThenInclude(t => t.Comments)
                .ToListAsync();
    }
}

