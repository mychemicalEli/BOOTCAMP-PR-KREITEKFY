using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("artist")]
public class Artist
{
    public long Id { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public string Name { get; set; }
}