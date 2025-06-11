using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.API.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSHOUSING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBilling _billingRepository;

        public BillingController(IBilling billingRepository)
        {
            _billingRepository = billingRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BillingDto>> GetAll()
        {
            var data = _billingRepository.GetAllAsync().Result;
            return Ok(data.Select(ToDto));
        }

        [HttpGet("{id}")]
        public ActionResult<BillingDto> Get(int id)
        {
            var billing = _billingRepository.GetByIdAsync(id).Result;
            if (billing == null) return NotFound();
            return Ok(ToDto(billing));
        }

        [HttpPost]
        public ActionResult<BillingDto> Post(BillingDto dto)
        {
            var entity = ToEntity(dto);
            var added = _billingRepository.AddAsync(entity).Result;
            return CreatedAtAction(nameof(Get), new { id = added.Id }, ToDto(added));
        }

        [HttpPut("{id}")]
        public ActionResult<BillingDto> Put(int id, BillingDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = _billingRepository.UpdateAsync(ToEntity(dto)).Result;
            return Ok(ToDto(updated));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _billingRepository.DeleteAsync(id).Result;
            if (!deleted) return NotFound();
            return NoContent();
        }

        // Simple mappers
        private BillingDto ToDto(Billing b) => new BillingDto
        {
            Id = b.Id,
            Name = b.Name,
            Flat = b.Flat,
            RentStatus = b.RentStatus,
            ServiceFees = b.ServiceFees,
            Dues = b.Dues
        };

        private Billing ToEntity(BillingDto d) => new Billing
        {
            Id = d.Id,
            Name = d.Name,
            Flat = d.Flat,
            RentStatus = d.RentStatus,
            ServiceFees = d.ServiceFees,
            Dues = d.Dues
        };
    }
}
