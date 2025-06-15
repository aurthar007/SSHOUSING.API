using System;

namespace SSHOUSING.Domain.Entities
{
    public class Billing
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Flat { get; set; } = string.Empty;
        public string RentStatus { get; set; } = string.Empty;

        public decimal ServiceFees { get; set; }   
        public decimal Dues { get; set; }          
        public decimal Rent { get; set; }          

        public decimal Amount { get; set; }       
        public DateTime Date { get; set; }        
    }
}
