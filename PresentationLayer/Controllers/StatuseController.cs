
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{

    public class StatuseController : BaseController
    {
        private readonly IStatuseService _statusServices;

        public StatuseController(IStatuseService statusServices)
        {
            _statusServices = statusServices;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatuses()
        {
            var statuses = await _statusServices.GetAllStatusesAsync();
            return Ok(statuses);
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var status = await _statusServices.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        // POST: api/Status
        [HttpPost]
        public async Task<ActionResult> AddStatus(StatusModel status)
        {
            await _statusServices.AddStatusAsync(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = status.Id }, status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStatus(int id, StatusModel status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            await _statusServices.UpdateStatusAsync(status);
            return NoContent();
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            await _statusServices.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}