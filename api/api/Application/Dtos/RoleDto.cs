using framework.Application.Dtos;

namespace api.Application.Dtos;

public class RoleDto : IDto
{
    public long Id { get; set; }
    public string Name { get; set; }
}