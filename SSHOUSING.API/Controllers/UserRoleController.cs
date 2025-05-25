using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userRole;

        public UserRoleController(IUserRole userRole)
        {
            _userRole = userRole;
        }

        [HttpGet("GetAllUserRoles")]
        public IActionResult GetAllUserRoles()
        {
            return Ok(_userRole.GetAll());
        }

        [HttpGet("GetUserRoleById/{id}")]
        public IActionResult GetUserRoleById(int id)
        {
            var userRole = _userRole.GetById(id);
            if (userRole == null) return NotFound();
            return Ok(userRole);
        }

        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole(UserRole userRole)
        {
            var result = _userRole.Add(userRole);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("UpdateUserRole")]
        public IActionResult UpdateUserRole(UserRole userRole)
        {
            var result = _userRole.Update(userRole);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("DeleteUserRole/{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            var result = _userRole.Delete(id);
            return result ? Ok() : NotFound();
        }
    }
}