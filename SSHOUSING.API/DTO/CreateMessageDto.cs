namespace SSHOUSING.API.DTO
{
    public class CreateMessageDto
    {
        public string Username { get; set; }  // ✅ changed from UserId to Username
        public string Content { get; set; }
    }
}
