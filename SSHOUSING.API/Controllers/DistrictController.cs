using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.API.DTO;
using SSHOUSING.Infrastucture; // Assuming ApplicationDbContext is here
using System.Linq;

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
            var districtDTOs = districts.Select(d => new DistrictDto
            {
                Id = d.Id,
                CountryId = d.CountryId,
                StateId = d.StateId,
                Name = d.Name
            }).ToList();

            return Ok(districtDTOs);
        }

        [HttpGet("GetDistrictById/{id}")]
        public IActionResult GetDistrict(int id)
        {
            var district = _district.GetDistrictById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            var districtDto = new DistrictDto
            {
                Id = district.Id,
                CountryId = district.CountryId,
                StateId = district.StateId,
                Name = district.Name
            };

            return Ok(districtDto);
        }

        [HttpPut("UpdateDistrict/{id}")]
        public IActionResult UpdateDistrict(int id, DistrictDto districtDto)
        {
            if (districtDto == null || id != districtDto.Id)
                return BadRequest("Invalid district data.");

            var district = _district.GetDistrictById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            var countryExists = _context.Countries.Any(c => c.Id == districtDto.CountryId);
            var stateExists = _context.States.Any(s => s.Id == districtDto.StateId);

            if (!countryExists)
                return BadRequest($"CountryId {districtDto.CountryId} is invalid.");

            if (!stateExists)
                return BadRequest($"StateId {districtDto.StateId} is invalid.");

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

            var countryExists = _context.Countries.Any(c => c.Id == districtDto.CountryId);
            var stateExists = _context.States.Any(s => s.Id == districtDto.StateId);

            if (!countryExists)
                return BadRequest($"CountryId {districtDto.CountryId} is invalid.");

            if (!stateExists)
                return BadRequest($"StateId {districtDto.StateId} is invalid.");

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
            return Ok("District deleted successfully.");
        }
    }
}
