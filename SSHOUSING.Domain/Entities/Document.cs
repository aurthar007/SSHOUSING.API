namespace SSHOUSING.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string DocumentType { get; set; } // e.g., Lease Agreement, Identity Proof
        public DateTime UploadedAt { get; set; }
    }
}
