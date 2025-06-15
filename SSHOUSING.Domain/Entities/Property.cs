namespace SSHOUSING.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public int Units { get; set; }              // ✅ Total number of units
        public int OccupiedUnits { get; set; }      // ✅ Used to calculate occupancy
    }
}
