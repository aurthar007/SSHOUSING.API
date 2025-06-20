using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Application.DTOs;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.MaintenanceRequests
                .Select(r => new MaintenanceRequestDto
                {
                    Id = r.Id,
                    Issue = r.Issue,
                    AssignedTo = r.AssignedTo,
                    Status = r.Status,
                
                }).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var r = _context.MaintenanceRequests.Find(id);
            if (r == null) return NotFound();

            var dto = new MaintenanceRequestDto
            {
                Id = r.Id,
                Issue = r.Issue,
                AssignedTo = r.AssignedTo,
                Status = r.Status,
            
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(MaintenanceRequestDto dto)
        {
            var r = new MaintenanceRequest
            {
                Issue = dto.Issue,
                AssignedTo = dto.AssignedTo,
                Status = dto.Status,
            
            };

            _context.MaintenanceRequests.Add(r);
            _context.SaveChanges();

            return Ok("Added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MaintenanceRequestDto dto)
        {
            var r = _context.MaintenanceRequests.Find(id);
            if (r == null) return NotFound();

            r.Issue = dto.Issue;
            r.AssignedTo = dto.AssignedTo;
            r.Status = dto.Status;
          

            _context.SaveChanges();

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var r = _context.MaintenanceRequests.Find(id);
            if (r == null) return NotFound();

            _context.MaintenanceRequests.Remove(r);
            _context.SaveChanges();

            return Ok("Deleted successfully");
        }
    }
}
