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
                Units = p.Units
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(PropertyDto dto)
        {
            var property = new Property
            {
                Name = dto.Name,
                Location = dto.Location,
                Units = dto.Units
            };

            var success = _repository.AddProperty(property);
            if (!success)
                return BadRequest("Failed to add property");

            dto.Id = property.Id;
            return Ok(dto);
        }
    }
}
