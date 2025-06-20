using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{role}")]
        public IActionResult GetUsersByRole(string role)
        {
            var users = _context.ManageUsers
                .Where(u => u.Role.ToLower() == role.ToLower())
                .Select(u => new ManageUsersDto
                {
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Role = u.Role
                })
                .ToList();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] ManageUsersDto dto)
        {
            var user = new ManageUsers
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role
            };

            _context.ManageUsers.Add(user);
            _context.SaveChanges();

            return Ok("User added successfully.");
        }
    }
}
