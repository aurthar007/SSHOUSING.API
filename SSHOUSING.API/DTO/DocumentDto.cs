namespace SSHOUSING.Application.DTOs
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string DocumentType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
