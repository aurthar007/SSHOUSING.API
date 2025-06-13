using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Entities
{
    public class MaintenanceRequest
    {
        public int Id { get; set; }
        public string Issue { get; set; } = string.Empty;
        public string? AssignedTo { get; set; }
        public string Status { get; set; } = "Pending"; // Default status
    }
}