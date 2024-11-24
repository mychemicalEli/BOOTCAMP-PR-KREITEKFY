using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("user_songs")]
public class UserSongs
{
    public long Id { get; set; }
    [ForeignKey("UserId")] public long UserId { get; set; }
    [ForeignKey("SongId")] public long SongId { get; set; }

    [Required] public DateTime PlayedAt { get; set; }
}