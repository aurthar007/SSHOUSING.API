using JWTTokendemo.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SSHOUSING.Infrastucture;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_context.Users.Any(x => x.Email == user.Email))
                return BadRequest("User with this email already exists.");

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully!");
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            var users = _context.Users.Select(u => new
            {
                u.Id,
                u.Username,
                u.Email
            }).ToList();

            return Ok(users);
        }
    }
}
