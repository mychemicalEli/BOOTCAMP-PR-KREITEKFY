using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

public class History
{
    public long Id { get; set; }    
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public long SongId { get; set; }
    [ForeignKey("SongId")]
    public Song Song { get; set; }
    public DateTime PlayedAt { get; set; }
}