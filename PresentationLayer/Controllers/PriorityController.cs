
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{

   
    public class PriorityController : BaseController
    {
        private readonly IPriorityService _priorityServices;

        public PriorityController(IPriorityService priorityServices)
        {
            _priorityServices = priorityServices;
        }

        // GET: api/Priority
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Priority>>> GetAllPriorities()
        {
            var priorities = await _priorityServices.GetAllPrioritiesAsync();
            return Ok(priorities);
        }

        // GET: api/Priority/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Priority>> GetPriorityById(int id)
        {
            var priority = await _priorityServices.GetPriorityByIdAsync(id);
            if (priority == null)
            {
                return NotFound();
            }

            return Ok(priority);
        }

        // POST: api/Priority
        [HttpPost]
        public async Task<ActionResult> AddPriority(PriorityModel priority)
        {
            await _priorityServices.AddPriorityAsync(priority);
            return CreatedAtAction(nameof(GetPriorityById), new { id = priority.Id }, priority);
        }

        // PUT: api/Priority/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePriority(int id, PriorityModel priority)
        {
            if (id != priority.Id)
            {
                return BadRequest();
            }

            await _priorityServices.UpdatePriorityAsync(priority);
            return NoContent();
        }

        // DELETE: api/Priority/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePriority(int id)
        {
            await _priorityServices.DeletePriorityAsync(id);
            return NoContent();
        }
    }
}
