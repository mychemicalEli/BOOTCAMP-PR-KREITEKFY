using api.Domain.Enums;
using framework.Application.Dtos;

namespace api.Application.Dtos;

public class UserDto: IDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}