using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Application.Interfaces; // ✅ Using the correct IProperty interface

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProperty _repository; // ✅ Match the interface name

        public PropertyController(IProperty repository) // ✅ Match the constructor parameter
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _repository.GetAllAsync();

            var result = properties.Select(p => new PropertyDto
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                Units = p.Units
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PropertyDto dto)
        {
            var property = new Property
            {
                Name = dto.Name,
                Location = dto.Location,
                Units = dto.Units
            };

            var added = await _repository.AddAsync(property);

            dto.Id = added.Id;
            return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
        }
    }
}
