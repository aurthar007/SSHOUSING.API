using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _country;
        public CountryController(ICountry country)
        {
            _country = country;
        }
        [HttpGet("GetAllCountry")]
        public IActionResult GetAllCountry()
        {
            return Ok(_country.GetAllCountry());
        }

        [HttpGet("GetCountryById/{id}")]
        public IActionResult GetCountry(int id)
        {
            var country = _country.GetCountryById(id);
            if (country == null)
                return NotFound($"Country with ID {id} not found.");

            return Ok(country);
        }

        [HttpPut("UpdateCountry/{id}")]
        public IActionResult UpdateCountry(int id, Country country)
        {
            if (country == null || country.Id != id)
                return BadRequest("Invalid country data.");
            var result = _country.UpdateCountry(country);
            return Ok("Country updated successfully.");

        }

        [HttpPost("AddCountry")]
        public IActionResult AddCountry(Country country)
        {
            if (country == null)
                return BadRequest("Invalid country data.");
            var result = _country.AddCountry(country);
            return Ok("Country added successfully.");
        }

        [HttpDelete("DeleteCountry/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var result = _country.DeleteCountry(id);
            return Ok("Country deleted successfully.");
        }

    }
}