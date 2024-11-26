using api.Domain.Entities;
using api.Domain.Persistence;
using framework.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class GenreRepository:GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(KreitekfyContext context) : base(context)
    {
    }
}