
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;


namespace PresentationLayer.Controllers
{
    public class UserTicketController : BaseController
    {
        private readonly IUserTicketServices _userTicketServices;

        public UserTicketController(IUserTicketServices userTicketServices)
        {
            _userTicketServices = userTicketServices;
        }

        // GET: api/UserTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTicketModel>>> GetAllUserTickets()
        {
            var userTickets = await _userTicketServices.GetAllUserTicketsAsync();
            return Ok(userTickets);
        }

        // GET: api/UserTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTicketModel>> GetUserTicketById(int id)
        {
            var userTicket = await _userTicketServices.GetUserTicketByIdAsync(id);
            if (userTicket == null)
            {
                return NotFound();
            }

            return Ok(userTicket);
        }

        // GET: api/UserTicket/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetUserTicketsByUserId(int userId)
        {
            var userTickets = await _userTicketServices.GetUserTicketsByUserIdAsync(userId);
            return Ok(userTickets);
        }

        // GET: api/UserTicket/Ticket/5
        [HttpGet("Ticket/{ticketId}")]
        public async Task<ActionResult<IEnumerable<UserTicketModel>>> GetUserTicketsByTicketId(int ticketId)
        {
            var userTickets = await _userTicketServices.GetUserTicketsByTicketIdAsync(ticketId);
            return Ok(userTickets);
        }

        // POST: api/UserTicket
        [HttpPost]
        public async Task<ActionResult<UserTicketModel>> AddUserTicket(UserTicketModel userTicketModel)
        {
            return CreatedAtAction(nameof(GetUserTicketById), new { id = userTicketModel.Id }, userTicketModel);
        }

        // PUT: api/UserTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserTicket(int id, UserTicketModel userTicketModel)
        {
            if (id != userTicketModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userTicketServices.UpdateUserTicketAsync(userTicketModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                var existingUserTicket = await _userTicketServices.GetUserTicketByIdAsync(id);
                if (existingUserTicket == null)
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

        // DELETE: api/UserTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTicket(int id)
        {
            var userTicket = await _userTicketServices.GetUserTicketByIdAsync(id);
            if (userTicket == null)
            {
                return NotFound();
            }

            await _userTicketServices.DeleteUserTicketAsync(id);
            return NoContent();
        }
    }
}
