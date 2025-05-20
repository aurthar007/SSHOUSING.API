using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO; 
using JWTTokendemo.DTO; 
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly IUserRole _userRole;

        public UserController(IUser user, IRole role, IUserRole userRole)
        {
            _user = user;
            _role = role;
            _userRole = userRole;
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
        public IActionResult Login(LoginRequest loginRequest)
        {
            var user = _user.Login(loginRequest.Email, loginRequest.Password);

            if (user == null)
                return Ok(new { name = "", role = "", success = "400" });

            var userRole = _userRole.GetById(user.Id);

            if (userRole == null)
                return Ok(new { name = "", role = "", success = "401" });

            var role = _role.GetRoleById(userRole.RoleId);

            return Ok(new { user = user, role = role, success = "200" });
        }
        
        }
    }

