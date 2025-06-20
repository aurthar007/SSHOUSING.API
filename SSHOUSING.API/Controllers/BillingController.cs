using Microsoft.AspNetCore.Mvc;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.API.DTO;
using System.Collections.Generic;
using System.Linq;

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
            var billings = _billingRepository.GetAllBilling();
            var result = billings.Select(ToDto).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<BillingDto> Get(int id)
        {
            var billing = _billingRepository.GetBillingById(id);
            if (billing == null) return NotFound();
            return Ok(ToDto(billing));
        }

        [HttpPost]
        public ActionResult<BillingDto> Post(BillingDto dto)
        {
            var entity = ToEntity(dto);
            var isAdded = _billingRepository.AddBilling(entity);

            if (!isAdded)
                return BadRequest("Failed to add billing record.");

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public ActionResult<BillingDto> Put(int id, BillingDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var isUpdated = _billingRepository.UpdateBilling(ToEntity(dto));
            if (!isUpdated)
                return NotFound("Billing record not found.");

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _billingRepository.DeleteBilling(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        // Mapping helpers
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
