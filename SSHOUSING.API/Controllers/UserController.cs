using Microsoft.AspNetCore.Http;
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
            return Ok(_user.Add(user));
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_user.Update(user));
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_user.Delete(id));
        }
    }
}
