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

        [HttpGet("GetAllCountries")]
        public IActionResult GetAllCountries()
        {
            return Ok(_country.GetAll());
        }

        [HttpGet("GetCountryById/{id}")]
        public IActionResult GetCountryById(int id)
        {
            var result = _country.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddCountries")]
        public IActionResult AddCountry(Country country)
        {
            return Ok(_country.Add(country));
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateCountry(Country country)
        {
            return Ok(_country.Update(country));
        }

        [HttpDelete("DeleteCountry/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            return Ok(_country.Delete(id));
        }
    }
}
