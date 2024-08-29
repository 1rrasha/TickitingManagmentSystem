
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{
   
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyModel company)
        {
            await _companyService.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyModel company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            try
            {
                await _companyService.UpdateCompanyAsync(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                var existingCompany = await _companyService.GetCompanyByIdAsync(id);
                if (existingCompany == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
