using api.Domain.Entities;
using api.Domain.Persistence;
using framework.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(KreitekfyContext context) : base(context)
    {
    }
}