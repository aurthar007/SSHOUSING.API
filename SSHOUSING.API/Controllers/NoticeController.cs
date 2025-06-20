using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastucture;
using System.Linq;

namespace SSHOUSING.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoticesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notices = _context.Notices.ToList();
            return Ok(notices);
        }

        [HttpPost]
        public IActionResult Add([FromBody] NoticeDto noticeDto)
        {
            var notice = new Notice { Message = noticeDto.Message };
            _context.Notices.Add(notice);
            _context.SaveChanges();
            return Ok(notice);
        }
    }
}
