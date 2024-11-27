using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("ratings")]
public class Rating
{
    public long Id { get; set; }
    [Required] public long UserId { get; set; }
    public User User { get; set; }
    [Required] public long SongId { get; set; }
    public Song Song { get; set; }
    [Range(1, 4)] public int Stars { get; set; }
}