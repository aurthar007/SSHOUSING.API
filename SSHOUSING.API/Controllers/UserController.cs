using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register a new user
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User user)
        {
            // Check if the email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
                return BadRequest("Email is already in use.");

            // Add the new user and save to the database
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }
        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] User loginRequest)
        {
            // Find user by email and password
            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            return Ok("Login successful.");
        }
    }
}
