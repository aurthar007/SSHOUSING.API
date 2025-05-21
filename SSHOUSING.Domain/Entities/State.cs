using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
