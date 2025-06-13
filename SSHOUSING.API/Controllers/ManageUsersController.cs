using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.API.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUsersController : ControllerBase
    {
        private readonly IManageUser _repository;

        public ManageUsersController(IManageUser repository)
        {
            _repository = repository;
        }

        [HttpGet("{role}")]
        public ActionResult<IEnumerable<ManageUsersDto>> GetUsersByRole(string role)
        {
            var users = _repository.GetUsersByRole(role);

            var userDtos = users.Select(u => new ManageUsersDto
            {
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role
            });

            return Ok(userDtos);
        }

        [HttpPost]
        public ActionResult<ManageUsersDto> AddUser([FromBody] ManageUsersDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Role))
                return BadRequest("Role is required.");

            var user = new ManageUsers
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role
            };

            var newUser = _repository.AddUser(user);

            var newDto = new ManageUsersDto
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Role = newUser.Role
            };

            return CreatedAtAction(nameof(GetUsersByRole), new { role = newUser.Role }, newDto);
        }
    }
}
