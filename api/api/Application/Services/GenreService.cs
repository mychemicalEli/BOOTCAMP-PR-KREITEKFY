using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using AutoMapper;
using framework.Application.Services;
using framework.Domain.Persistence;

namespace api.Application.Services;

public class GenreService:GenericService<Genre, GenreDto>,IGenreService
{
    public GenreService(IGenreRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}