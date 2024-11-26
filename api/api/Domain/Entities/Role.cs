using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities;

[Table("roles")]
public class Role
{
    public long Id { get; set; }
    [Required] [MinLength(3)] public string Name { get; set; }
}