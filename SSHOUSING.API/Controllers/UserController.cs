using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO; // For LoginRegister
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
    }
}
