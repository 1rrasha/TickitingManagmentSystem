
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{

  
    public class UserController : BaseController
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userServices.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> AddUser(UserModel user)
        {
            await _userServices.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userServices.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userServices.DeleteUserAsync(id);
            return NoContent();
        }

        // GET: api/User/email
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userServices.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/User/company/5
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByCompanyId(int companyId)
        {
            var users = await _userServices.GetUsersByCompanyIdAsync(companyId);
            return Ok(users);
        }
    }
}