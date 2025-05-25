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
  

        public UserController(IUser user, IRole role, IUserRole userRole)
        {
            _user = user;
         
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
