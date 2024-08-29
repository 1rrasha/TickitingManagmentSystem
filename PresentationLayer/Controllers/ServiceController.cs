
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;


namespace PresentationLayer.Controllers
{

    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceServices;

        public ServiceController(IServiceService serviceServices)
        {
            _serviceServices = serviceServices;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
        {
            var services = await _serviceServices.GetAllServicesAsync();
            return Ok(services);
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var service = await _serviceServices.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // GET: api/Service/Company/5
        [HttpGet("Company/{companyId}")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesByCompanyId(int companyId)
        {
            var services = await _serviceServices.GetServicesByCompanyIdAsync(companyId);
            return Ok(services);
        }

        // POST: api/Service
        [HttpPost]
        public async Task<ActionResult> AddService(ServiceModel service)
        {
            await _serviceServices.AddServiceAsync(service);
            return CreatedAtAction(nameof(GetServiceById), new { id = service.Id }, service);
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, ServiceModel service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            await _serviceServices.UpdateServiceAsync(service);
            return NoContent();
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            await _serviceServices.DeleteServiceAsync(id);
            return NoContent();
        }
    }
}
