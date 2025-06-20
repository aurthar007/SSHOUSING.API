using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class Billing
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Flat { get; set; }
        public string RentStatus { get; set; }
        public string ServiceFees { get; set; }
        public string Dues { get; set; }
    }
}
