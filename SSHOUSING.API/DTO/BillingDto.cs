// DTOs/BillingDto.cs
namespace SSHOUSING.API.DTO
{
    public class BillingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flat { get; set; }
        public string RentStatus { get; set; }
        public decimal ServiceFees { get; set; }  // ✅ Correct type
        public decimal Dues { get; set; }         // ✅ Correct type
    }
}
