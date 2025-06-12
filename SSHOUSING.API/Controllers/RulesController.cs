using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;

namespace SSHOUSING.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rules = _context.Rules.ToList();
            return Ok(rules);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RuleDto ruleDto)
        {
            var rule = new Rule { Description = ruleDto.Description };
            _context.Rules.Add(rule);
            _context.SaveChanges();
            return Ok(rule);
        }
    }
}
