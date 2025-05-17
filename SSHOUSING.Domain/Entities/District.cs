using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }
}
