using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSHOUSING.API.DTO;
using JWTTokendemo.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly IUserRole _userRole;
        private readonly IConfiguration _configuration;

        public UserController(IUser user, IRole role, IUserRole userRole, IConfiguration configuration)
        {
            _user = user;
            _role = role;
            _userRole = userRole;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register(LoginRegister request)
        {
            var user = new User
            {
                Id = request.Id,
                Username = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var result = _user.AddUser(user);
            if (!result)
                return BadRequest("User registration failed.");

            return Ok("Registered successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest userLogin)
        {
            var user = _user.Login(userLogin.Email, userLogin.Password);

            if (user == null)
                return Unauthorized(new
                {
                    token = "",
                    name = "",
                    role = "",
                    success = "400",
                    message = "Invalid credentials"
                });

            // ✅ FIX: Lookup by UserId not UserRole.Id
            var userRole = _userRole.GetUserRoleByUserId(user.Id);
            if (userRole == null)
                return NotFound(new
                {
                    token = "",
                    name = user.Username,
                    role = "",
                    success = "401",
                    message = "Role not assigned"
                });

            var role = _role.GetRoleById(userRole.RoleId);
            if (role == null)
                return NotFound(new
                {
                    token = "",
                    name = user.Username,
                    role = "",
                    success = "402",
                    message = "Role not found"
                });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpiresInHours"])),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = jwt,
                name = user.Username,
                role = role.Name,
                success = "200"
            });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _user.GetAllUser();
            return Ok(users);
        }
    }
}
