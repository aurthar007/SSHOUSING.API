using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProperty _repository;

        public PropertyController(IProperty repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _repository.GetAllProperty();
            var result = data.Select(p => new PropertyDto
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                Units = p.Units,
                OccupiedUnits = p.OccupiedUnits
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _repository.GetPropertyById(id);
            if (p == null)
                return NotFound();

            var dto = new PropertyDto
            {
                Id = p.Id,
                Name = p.Name,
                Location = p.Location,
                Units = p.Units,
                OccupiedUnits = p.OccupiedUnits
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(PropertyDto dto)
        {
            var property = new Property
            {
                Name = dto.Name,
                Location = dto.Location,
                Units = dto.Units,
                OccupiedUnits = dto.OccupiedUnits
            };

            var success = _repository.AddProperty(property);
            if (!success)
                return BadRequest("Failed to add property");

            dto.Id = property.Id;
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PropertyDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched ID");

            // Just forward to repository
            var propertyToUpdate = new Property
            {
                Id = dto.Id,
                Name = dto.Name,
                Location = dto.Location,
                Units = dto.Units,
                OccupiedUnits = dto.OccupiedUnits
            };

            var success = _repository.UpdateProperty(propertyToUpdate);
            if (!success)
                return NotFound("Update failed. Property might not exist.");

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _repository.DeleteProperty(id);
            if (!success)
                return NotFound("Property not found or delete failed");

            return Ok("Property deleted successfully");
        }
    }
}
