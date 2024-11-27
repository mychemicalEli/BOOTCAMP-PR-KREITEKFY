using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("songs")]
public class Song
{
    public long Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    [Required] public long ArtistId { get; set; }
    [Required] public Artist Artist { get; set; }
    [Required] public long AlbumId { get; set; }
    [Required] public Album Album { get; set; }

    [Required] public long GenreId { get; set; }
    [Required] public Genre Genre { get; set; }
    [Required] public TimeSpan Duration { get; set; }
    [Required] [Range(1, 4)] public decimal MediaRating { get; set; }
    [Required] [Range(0, long.MaxValue)] public long Streams { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;
    public ICollection<Rating> Ratings { get; set; }
    public ICollection<UserSongs> UserSongs { get; set; }
}