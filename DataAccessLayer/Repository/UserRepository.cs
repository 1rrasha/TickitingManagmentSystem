
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetUsersByCompanyIdAsync(int companyId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public UserRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking() // Use AsNoTracking for read-only scenarios
                .Include(u => u.Company)
                .Include(u => u.UserTickets)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking() // Use AsNoTracking for read-only scenarios
                .Include(u => u.Company)
                .Include(u => u.UserTickets)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .AsNoTracking() // Use AsNoTracking for read-only scenarios
                .Include(u => u.Company)
                .Include(u => u.UserTickets)
                .ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log and handle the exception as needed
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency issues
                throw new Exception("A concurrency error occurred while updating the user.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Log and handle the exception as needed
                throw new Exception("An error occurred while updating the user.", ex);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                try
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Log and handle the exception as needed
                    throw new Exception("An error occurred while deleting the user.", ex);
                }
            }
            else
            {
                throw new KeyNotFoundException("User not found.");
            }
        }

        public async Task<IEnumerable<User>> GetUsersByCompanyIdAsync(int companyId)
        {
            return await _context.Users
                .AsNoTracking() // Use AsNoTracking for read-only scenarios
                .Where(u => u.CompanyId == companyId)
                .Include(u => u.Company)
                .ToListAsync();
        }
    }
}
