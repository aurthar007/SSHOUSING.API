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
            var userRoles = _userRole.GetAllUserRole();
            return Ok(userRoles);
        }

        [HttpGet("GetUserRoleById/{id}")]
        public IActionResult GetUserRoleById(int id)
        {
            var userRole = _userRole.GetUserRoleById(id);
            if (userRole == null)
                return NotFound("User role not found.");
            return Ok(userRole);
        }

        // ✅ NEW: Get by UserId
        [HttpGet("GetByUserId/{userId}")]
        public IActionResult GetUserRoleByUserId(int userId)
        {
            var userRole = _userRole.GetUserRoleByUserId(userId);
            if (userRole == null)
                return NotFound("No role assigned to this user.");
            return Ok(userRole);
        }

        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole([FromBody] UserRole userRole)
        {
            var result = _userRole.Add(userRole);
            return result
                ? Ok("User role added successfully.")
                : BadRequest("Failed to add user role.");
        }

        [HttpPut("UpdateUserRole")]
        public IActionResult UpdateUserRole([FromBody] UserRole userRole)
        {
            var result = _userRole.Update(userRole);
            return result
                ? Ok("User role updated successfully.")
                : NotFound("User role not found.");
        }

        [HttpDelete("DeleteUserRole/{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            var result = _userRole.Delete(id);
            return result
                ? Ok("User role deleted successfully.")
                : NotFound("User role not found.");
        }
    }
}
