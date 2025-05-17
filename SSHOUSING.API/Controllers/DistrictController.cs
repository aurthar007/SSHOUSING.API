using Microsoft.AspNetCore.Http;
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
            var district = _district.GetById(id);
            if (district == null) return NotFound();
            return Ok(district);
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            _district.Add(district);
            return Ok();
        }

        [HttpPut("UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            var result = _district.Update(district);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("DeleteDistrict/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var result = _district.Delete(id);
            if (result) return Ok();
            return NotFound();
        }
    }
}