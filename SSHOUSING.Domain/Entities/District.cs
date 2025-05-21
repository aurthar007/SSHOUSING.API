using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}