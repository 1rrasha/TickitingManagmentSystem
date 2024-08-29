
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<IEnumerable<Service>> GetServicesByCompanyIdAsync(int companyId);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }

    public class ServiceRepository : IServiceRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public ServiceRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services
                                 .Include(s => s.Company) // Include Company entity
                                 .ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services
                                 .Include(s => s.Company) // Include Company entity
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Service>> GetServicesByCompanyIdAsync(int companyId)
        {
            return await _context.Services
                                 .Include(s => s.Company) // Include Company entity
                                 .Where(s => s.CompanyId == companyId)
                                 .ToListAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
                throw new KeyNotFoundException("Service not found.");

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
