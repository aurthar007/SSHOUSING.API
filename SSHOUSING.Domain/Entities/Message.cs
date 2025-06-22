using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Message
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime PostedAt { get; set; } = DateTime.Now;

    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }
}
