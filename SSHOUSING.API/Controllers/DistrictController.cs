using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrict _district;
        public DistrictController(IDistrict district)
        {
            _district = district;
        }
        [HttpGet("GetAllDistrict")]
        public IActionResult GetAllDistrict()
        {
            return Ok(_district.GetAllDistrict());
        }

        [HttpGet("GetDistrictById/{id}")]
        public IActionResult GetDistrict(int id)
        {
            var district = _district.GetDistrictById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            return Ok(district);
        }

        [HttpPut("UpdateDistrict/{id}")]
        public IActionResult UpdateDistrict(int id, District district)
        {
            if (district == null || district.Id != id)
                return BadRequest("Invalid district data.");
            var result = _district.UpdateDistrict(district);
            return Ok("District updated successfully.");

        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            if (district == null)
                return BadRequest("Invalid district data.");
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