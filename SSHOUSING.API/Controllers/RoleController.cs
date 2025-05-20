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

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_role.GetAll());
        }

        [HttpGet("GetRoleById/{id}")]
        public IActionResult GetRoleById(int id)
        {
            var result = _role.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        {
            return Ok(_role.Create(role));
        }

        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            return Ok(_role.Update(role));
        }

        [HttpDelete("DeleteRole/{id}")]
        public IActionResult DeleteRole(int id)
        {
            return Ok(_role.Delete(id));
        }
    }
}
