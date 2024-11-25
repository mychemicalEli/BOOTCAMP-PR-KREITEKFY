using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api.Domain.Enums;

namespace api.Domain.Entities;

[Table("songs")]
public class Song
{
    public long Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    [Required] [MaxLength(255)] public string Artist { get; set; }
    [Required] [MaxLength(255)] public string Album { get; set; }
    [Required] public byte[] AlbumCover { get; set; }

    [Required]
    public Genres Genre { get; set; }

    [Required] public TimeSpan Duration { get; set; }
    [Required] [Range(1, 4)] public decimal Rating { get; set; }
    [Required] [Range(0, long.MaxValue)] public long Streams { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;
  
}