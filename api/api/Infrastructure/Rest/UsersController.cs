using api.Application.Dtos;
using api.Application.Services;
using framework.Application.Services;
using framework.Infrastructure.Rest;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Rest;

[Route("api/[controller]")]
[ApiController]
public class UsersController:GenericCrudController<UserDto>
{
    public UsersController(IUserService service) : base(service)
    {
    }
}