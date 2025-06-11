using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrict _district;
        private readonly ApplicationDbContext _context;

        public DistrictController(IDistrict district, ApplicationDbContext context)
        {
            _district = district;
            _context = context;
        }

        [HttpGet("GetAllDistrict")]
        public IActionResult GetAllDistrict()
        {
            var districts = _district.GetAllDistrict();
            var DistrictDto = districts.Select(d => new DistrictDto
            {
                Id = d.Id,
                CountryId = d.CountryId,
                StateId = d.StateId,
                Name = d.Name
            }).ToList();

            return Ok(DistrictDto);
        }

        [HttpGet("GetDistrictById/{id}")]
        public IActionResult GetDistrict(int id)
        {
            var district = _district.GetDistrictById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            var DistrictDto = new DistrictDto
            {
                Id = district.Id,
                CountryId = district.CountryId,
                StateId = district.StateId,
                Name = district.Name
            };

            return Ok(DistrictDto);
        }

        [HttpPut("UpdateDistrict/{id}")]
        public IActionResult UpdateDistrict(int id, DistrictDto districtDto)
        {
            if (districtDto == null || id != districtDto.Id)
                return BadRequest("Invalid district data.");

            if (!_context.Countries.Any(c => c.Id == districtDto.CountryId))
                return BadRequest("Invalid CountryId.");

            if (!_context.States.Any(s => s.Id == districtDto.StateId))
                return BadRequest("Invalid StateId.");

            var district = _district.GetDistrictById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            district.Name = districtDto.Name;
            district.CountryId = districtDto.CountryId;
            district.StateId = districtDto.StateId;

            var result = _district.UpdateDistrict(district);
            return Ok("District updated successfully.");
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(DistrictDto districtDto)
        {
            if (districtDto == null)
                return BadRequest("Invalid district data.");

            if (!_context.Countries.Any(c => c.Id == districtDto.CountryId))
                return BadRequest("Invalid CountryId.");

            if (!_context.States.Any(s => s.Id == districtDto.StateId))
                return BadRequest("Invalid StateId.");

            var district = new District
            {
                CountryId = districtDto.CountryId,
                StateId = districtDto.StateId,
                Name = districtDto.Name
            };

            var result = _district.AddDistrict(district);
            return Ok("District added successfully.");
        }

        [HttpDelete("DeleteDistrict/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var result = _district.DeleteDistrict(id);
            if (!result)
                return NotFound($"District with ID {id} not found.");

            return Ok("District deleted successfully.");
        }
    }
}
