using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }
        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        {
            if (role == null)
                return BadRequest("Invalid Role data.");
            var result = _role.AddRole(role);
            return Ok("Role added successfully.");
        }
        [HttpGet("GetAllRole")]
        public IActionResult GetAllRole()
        {
            return Ok(_role.GetAllRole());
        }

        [HttpGet("GetRoleById/{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _role.GetRoleById(id);
            if (role == null)
                return NotFound($"role with ID {id} not found.");

            return Ok(role);
        }

        [HttpPut("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id, Role role)
        {
            if (role == null || role.Id != id)
                return BadRequest("Invalid role data.");
            var result = _role.UpdateRole(role);
            return Ok("Role updated successfully.");

        }

        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var result = _role.DeleteRole(id);
            return Ok("Role deleted successfully.");
        }


    }
}