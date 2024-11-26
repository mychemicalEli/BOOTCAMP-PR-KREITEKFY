using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("albums")]
public class Album
{
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(1)]
    public string Title { get; set; }

    [Required] public byte[] Cover { get; set; }
    [Required] public long ArtistId { get; set; }
    [Required] public Artist Artist { get; set; }
    public ICollection<Song> Songs { get; set; }
}