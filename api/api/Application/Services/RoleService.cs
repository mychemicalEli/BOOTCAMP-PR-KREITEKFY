using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using AutoMapper;
using framework.Application.Services;
using framework.Domain.Persistence;

namespace api.Application.Services;

public class RoleService : GenericService<Role, RoleDto>, IRoleService
{
    public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}