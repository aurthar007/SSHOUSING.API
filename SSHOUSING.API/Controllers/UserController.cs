using JWTTokendemo.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

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

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
                return BadRequest("Email is already in use.");

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromServices] IConfiguration configuration, [FromBody] LoginRequest loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            if (userRole == null)
                return Unauthorized("User role not found.");

            var role = _context.Roles.Find(userRole.RoleId)?.Name;
            if (role == null)
                return Unauthorized("Role not found.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: null,
                expires: DateTime.Now.AddHours(Convert.ToDouble(configuration["Jwt:ExpiresInHours"])),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = jwt, user = user, role = role, success = "200" });
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
