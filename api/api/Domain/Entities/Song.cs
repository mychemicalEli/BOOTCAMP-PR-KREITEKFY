using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Domain.Enums;

namespace api.Domain.Entities;
[Table("songs")]
public class Song
{
    public long Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    [Required]
    [MaxLength(255)]
    public string Artist { get; set; }
    [Required]
    [MaxLength(255)]
    public string Album { get; set; }
    [Required]
    public byte[] AlbumCover { get; set; }
    [Required]
    [EnumDataType(typeof(Genres))]
    public Genres Genre { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    [Required]
    [Range(1, 4)]
    public decimal Rating { get; set; }
    [Required]
    [Range(0, long.MaxValue)]
    public long Streams { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}