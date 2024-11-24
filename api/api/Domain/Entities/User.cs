using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Domain.Enums;

namespace api.Domain.Entities;

[Table("users")]
public class User
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    public string Password { get; set; }

    [Required] public Roles Role { get; set; }
 
}