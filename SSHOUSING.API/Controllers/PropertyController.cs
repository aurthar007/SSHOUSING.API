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
    public class PropertyController : ControllerBase
    {
        private readonly IProperty _propertyRepository;

        public PropertyController(IProperty propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // ✅ GET: api/Property
        [HttpGet]
        public ActionResult<IEnumerable<PropertyDto>> GetAllProperty()
        {
            var properties = _propertyRepository.GetAllProperty();
            var result = properties.Select(ToDto).ToList();
            return Ok(result);
        }

        // ✅ GET: api/Property/5
        [HttpGet("{id}")]
        public ActionResult<PropertyDto> GetPropertyById(int id)
        {
            var property = _propertyRepository.GetPropertyById(id);
            if (property == null)
                return NotFound($"Property with ID {id} not found.");

            return Ok(ToDto(property));
        }

        // ✅ POST: api/Property
        [HttpPost]
        public ActionResult<PropertyDto> AddProperty([FromBody] PropertyDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid property data.");

            var property = ToEntity(dto);
            var success = _propertyRepository.AddProperty(property);
            if (!success)
                return StatusCode(500, "Failed to add property.");

            dto.Id = property.Id;
            return CreatedAtAction(nameof(GetPropertyById), new { id = dto.Id }, dto);
        }

        // ✅ PUT: api/Property/5
        [HttpPut("{id}")]
        public ActionResult UpdateProperty(int id, [FromBody] PropertyDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest("Invalid property data.");

            var updated = _propertyRepository.UpdateProperty(ToEntity(dto));
            if (!updated)
                return NotFound($"Property with ID {id} not found.");

            return Ok("Property updated successfully.");
        }

        // ✅ DELETE: api/Property/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProperty(int id)
        {
            var deleted = _propertyRepository.DeleteProperty(id);
            if (!deleted)
                return NotFound($"Property with ID {id} not found.");

            return Ok("Property deleted successfully.");
        }

        // 🔄 Mapping methods
        private PropertyDto ToDto(Property p) => new PropertyDto
        {
            Id = p.Id,
            Name = p.Name,
            Location = p.Location,
            Units = p.Units,
            OccupiedUnits = p.OccupiedUnits
        };

        private Property ToEntity(PropertyDto dto) => new Property
        {
            Id = dto.Id,
            Name = dto.Name,
            Location = dto.Location,
            Units = dto.Units,
            OccupiedUnits = dto.OccupiedUnits
        };
    }
}
