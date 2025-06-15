namespace SSHOUSING.API.DTO
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Units { get; set; }
        public int OccupiedUnits { get; set; }
    }
}
