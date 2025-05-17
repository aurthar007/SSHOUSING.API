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

        [HttpGet("GetAllDistricts")]
        public IActionResult GetAllDistricts()
        {
            return Ok(_district.GetAll());
        }

        [HttpGet("GetDistrictById/{id}")]
        public IActionResult GetDistrictById(int id)
        {
            var result = _district.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            return Ok(_district.Add(district));
        }

        [HttpPut("UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            return Ok(_district.Update(district));
        }

        [HttpDelete("DeleteDistrict/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            return Ok(_district.Delete(id));
        }
    }
}
