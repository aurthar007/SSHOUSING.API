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
        [HttpGet("GetAllUserRole")]
        public IActionResult GetAllUserRole()
        {
            return Ok(_userRole.GetAllUserRole());
        }
    }
}
