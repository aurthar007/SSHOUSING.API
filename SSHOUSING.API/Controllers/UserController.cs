using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user= user;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_user.GetAll());
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _user.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            var result = _user.Create(user);
            return result ? Ok("User created successfully.") : BadRequest("Failed to create user.");
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _user.Update(user);
            return result ? Ok("User updated successfully.") : NotFound("User not found.");
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _user.Delete(id);
            return result ? Ok("User deleted successfully.") : NotFound("User not found.");
        }
    }
}
