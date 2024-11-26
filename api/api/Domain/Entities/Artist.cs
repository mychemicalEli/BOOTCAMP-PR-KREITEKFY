using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;
[Table("artist")]
public class Artist
{
    public long Id { get; set; }
    public string Name { get; set; }
}