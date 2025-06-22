
using System.ComponentModel.DataAnnotations;

namespace SSHOUSING.Domain.Entities
{
    public class Income
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public decimal Rent { get; set; }

        [Required]
        public decimal Maintenance { get; set; }
    }
}
