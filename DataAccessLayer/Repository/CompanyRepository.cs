
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TicketingManagementSystemContext _context;

        public CompanyRepository(TicketingManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task AddCompanyAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                throw new KeyNotFoundException("Company not found.");

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}

