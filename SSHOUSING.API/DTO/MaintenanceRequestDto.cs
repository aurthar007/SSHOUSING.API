namespace SSHOUSING.Application.DTOs
{
    public class MaintenanceRequestDto
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public string? AssignedTo { get; set; }
        public string Status { get; set; }
      
    }
}
