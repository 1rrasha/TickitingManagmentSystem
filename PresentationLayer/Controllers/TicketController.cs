
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{

  
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketServices;

        public TicketController(ITicketService ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetAllTickets()
        {
            var tickets = await _ticketServices.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResource>> GetTicketById(int id)
        {
            var ticket = await _ticketServices.GetTicketByIdAsync(id)
;
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket)
;
        }

        [HttpGet("Company/{companyId}")]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetTicketsByCompanyId(int companyId)
        {
            var tickets = await _ticketServices.GetTicketsByCompanyIdAsync(companyId);
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<ActionResult<TicketModel>> AddTicket(TicketModel ticketModel)
        {
            var ticket = await _ticketServices.AddTicketAsync(ticketModel);

            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, TicketModel ticketModel)
        {
            if (id != ticketModel.Id)
            {
                return BadRequest();
            }

            var ticket = ticketModel;

            try
            {
                await _ticketServices.UpdateTicketAsync(ticketModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                var existingTicket = await _ticketServices.GetTicketByIdAsync(id)
;
                if (existingTicket == null)
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
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketServices.GetTicketByIdAsync(id)
;
            if (ticket == null)
            {
                return NotFound();
            }

            await _ticketServices.DeleteTicketAsync(id)
;
            return NoContent();
        }
    }
}