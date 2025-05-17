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
            _user = user;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_user.GetAll());
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _user.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            var result = _user.Create(user);
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _user.Update(user);
            return Ok(result);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _user.Delete(id);
            return Ok(result);
        }
    }
}
