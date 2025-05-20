using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        public string Name { get; set; }
    }
}
