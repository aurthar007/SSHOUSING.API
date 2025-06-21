using Microsoft.AspNetCore.Mvc;
using SSHOUSING.API.DTO;
using SSHOUSING.Application.DTOs;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
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
        public ActionResult<BillingDto> GetById(int id)
        {
            var billing = _billingRepository.GetBillingById(id);
            if (billing == null)
                return NotFound($"Billing record with ID {id} not found.");

            return Ok(ToDto(billing));
        }

     
        [HttpPost]
        public ActionResult<BillingDto> AddBilling([FromBody] BillingDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid billing data.");

            var billing = ToEntity(dto);
            var isAdded = _billingRepository.AddBilling(billing);
            if (!isAdded)
                return StatusCode(500, "Failed to add billing record.");

            return CreatedAtAction(nameof(GetById), new { id = billing.Id }, ToDto(billing));
        }

      
        [HttpPut("{id}")]
        public ActionResult UpdateBilling(int id, [FromBody] BillingDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest("Invalid billing data.");

            var isUpdated = _billingRepository.UpdateBilling(ToEntity(dto));
            if (!isUpdated)
                return NotFound($"Billing record with ID {id} not found.");

            return Ok("Billing updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBilling(int id)
        {
            var isDeleted = _billingRepository.DeleteBilling(id);
            if (!isDeleted)
                return NotFound($"Billing record with ID {id} not found.");

            return Ok("Billing deleted successfully.");
        }

        [HttpGet("RevenueStats")]
        public ActionResult<IEnumerable<RevenueDto>> GetMonthlyRevenueStats()
        {
            var stats = _billingRepository.GetMonthlyRevenueStats();

            var result = stats.Select(s => new RevenueDto
            {
                Month = s.Month,
                TotalRevenue = s.TotalRevenue
            }).ToList();

            return Ok(result);
        }

    
        private BillingDto ToDto(Billing b) => new BillingDto
        {
            Id = b.Id,
            Name = b.Name,
            Flat = b.Flat,
            RentStatus = b.RentStatus,
            ServiceFees = b.ServiceFees,
            Dues = b.Dues,
            Rent = b.Rent,
            Amount = b.Amount,
            Date = b.Date
        };

        private Billing ToEntity(BillingDto d) => new Billing
        {
            Id = d.Id,
            Name = d.Name,
            Flat = d.Flat,
            RentStatus = d.RentStatus,
            ServiceFees = d.ServiceFees,
            Dues = d.Dues,
            Rent = d.Rent,
            Amount = d.Amount,
            Date = d.Date
        };
    }
}
