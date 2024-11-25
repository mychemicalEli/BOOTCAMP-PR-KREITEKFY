using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using AutoMapper;
using framework.Application.Services;

namespace api.Application.Services;

public class UserService : GenericService<User, UserDto>, IUserService
{
    public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}