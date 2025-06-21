using System;

namespace SSHOUSING.API.DTO
{
    public class BillingDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Flat { get; set; }
        public required string RentStatus { get; set; }

        public decimal ServiceFees { get; set; }
        public decimal Dues { get; set; }
        public decimal Rent { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}