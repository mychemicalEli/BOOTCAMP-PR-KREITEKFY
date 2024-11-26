using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("genres")]
public class Genre
{
    public long Id { get; set; }
    [Required] [MinLength(3)] public string Name { get; set; }
    public ICollection<Song> Songs { get; set; } = new List<Song>();
}