using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Income
        [HttpGet]
        public IActionResult GetAll()
        {
            var incomes = _context.Incomes.ToList();
            return Ok(incomes);
        }

        // GET: api/Income/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var income = _context.Incomes.Find(id);
            if (income == null)
                return NotFound();

            return Ok(income);
        }

        // POST: api/Income
        [HttpPost]
        public IActionResult Add([FromBody] Income income)
        {
            _context.Incomes.Add(income);
            var result = _context.SaveChanges();
            if (result > 0)
                return Ok("Income added successfully.");
            return BadRequest("Failed to add income.");
        }

        // PUT: api/Income/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Income income)
        {
            var existing = _context.Incomes.Find(id);
            if (existing == null)
                return NotFound();

            existing.Month = income.Month;
            existing.Rent = income.Rent;
            existing.Maintenance = income.Maintenance;

            _context.Incomes.Update(existing);
            _context.SaveChanges();

            return Ok("Income updated successfully.");
        }

        // DELETE: api/Income/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var income = _context.Incomes.Find(id);
            if (income == null)
                return NotFound();

            _context.Incomes.Remove(income);
            _context.SaveChanges();

            return Ok("Income deleted successfully.");
        }
    }
}
