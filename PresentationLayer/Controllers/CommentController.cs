
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using Microsoft.AspNetCore.Authorization;
using Presentation_Layer.Controllers;

namespace PresentationLayer.Controllers
{
   
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResource>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // GET: api/Comment/Ticket/5
        [HttpGet("Ticket/{ticketId}")]
        public async Task<ActionResult<IEnumerable<CommentResource>>> GetCommentsByTicketId(int ticketId)
        {
            var comments = await _commentService.GetCommentsByTicketIdAsync(ticketId);
            return Ok(comments);
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<ActionResult> AddComment(CommentModel comment)
        {
            await _commentService.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, CommentModel comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            await _commentService.UpdateCommentAsync(comment);
            return NoContent();
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
