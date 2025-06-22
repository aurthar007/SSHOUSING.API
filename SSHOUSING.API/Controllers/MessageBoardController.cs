using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageBoardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessageBoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Get all messages
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            var messages = _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.PostedAt)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Username = m.User.Username,
                    Content = m.Content,
                    PostedAt = m.PostedAt
                })
                .ToList();

            return Ok(messages);
        }

        // ✅ Get messages by user ID
        [HttpGet("user/{userId}")]
        public IActionResult GetMessagesByUser(int userId)
        {
            var messages = _context.Messages
                .Include(m => m.User)
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.PostedAt)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Username = m.User.Username,
                    Content = m.Content,
                    PostedAt = m.PostedAt
                })
                .ToList();

            return Ok(messages);
        }

        // ✅ Post a new message using username
        [HttpPost]
        public IActionResult PostMessage([FromBody] CreateMessageDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                return BadRequest("Username is required.");

            if (string.IsNullOrWhiteSpace(dto.Content))
                return BadRequest("Message content is required.");

            var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null)
                return BadRequest("Only registered users can post messages.");

            var message = new Message
            {
                UserId = user.Id,
                Content = dto.Content,
                PostedAt = DateTime.Now
            };

            try
            {
                _context.Messages.Add(message);
                _context.SaveChanges();

                return Ok(new MessageDto
                {
                    Id = message.Id,
                    Username = user.Username,
                    Content = message.Content,
                    PostedAt = message.PostedAt
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
