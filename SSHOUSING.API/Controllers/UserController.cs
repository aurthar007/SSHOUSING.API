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
            return Ok("Registered successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest userLogin)
        {
            var user = _user.Login(userLogin.Email, userLogin.Password);

            if (user == null)
                return Ok(new { token = "", name = "", role = "", success = "400" });

            var userRole = _userRole.GetById(user.Id);

            if (userRole == null)
                return Ok(new { token = "", name = "", role = "", success = "401" });
            else
            {
                var role = _role.GetRoleById(userRole.RoleId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role.Name),
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
                return Ok(new { token = jwt, user = user, role = role, success = "200" });
            }
        }
    }
}