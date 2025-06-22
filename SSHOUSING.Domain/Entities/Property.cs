using System.ComponentModel.DataAnnotations;

namespace SSHOUSING.Domain.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Property name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Units must be a non-negative number")]
        public int Units { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Occupied Units must be a non-negative number")]
        public int OccupiedUnits { get; set; }
    }
}
