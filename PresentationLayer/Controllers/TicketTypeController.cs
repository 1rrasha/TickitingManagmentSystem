
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;
namespace PresentationLayer.Controllers
{

   
    public class TicketTypeController : BaseController
    {
        private readonly ITicketTypeService _ticketTypeServices;

        public TicketTypeController(ITicketTypeService ticketTypeServices)
        {
            _ticketTypeServices = ticketTypeServices;
        }

        // GET: api/TicketType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetAllTicketTypes()
        {
            var ticketTypes = await _ticketTypeServices.GetAllTicketTypesAsync();
            return Ok(ticketTypes);
        }

        // GET: api/TicketType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketType>> GetTicketTypeById(int id)
        {
            var ticketType = await _ticketTypeServices.GetTicketTypeByIdAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            return Ok(ticketType);
        }

        // POST: api/TicketType
        [HttpPost]
        public async Task<ActionResult> AddTicketType(TicketTypeModel ticketType)
        {
            await _ticketTypeServices.AddTicketTypeAsync(ticketType);
            return CreatedAtAction(nameof(GetTicketTypeById), new { id = ticketType.Id }, ticketType);
        }

        // PUT: api/TicketType/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTicketType(int id, TicketTypeModel ticketType)
        {
            if (id != ticketType.Id)
            {
                return BadRequest();
            }

            await _ticketTypeServices.UpdateTicketTypeAsync(ticketType);
            return NoContent();
        }

        // DELETE: api/TicketType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicketType(int id)
        {
            await _ticketTypeServices.DeleteTicketTypeAsync(id);
            return NoContent();
        }
    }
}
