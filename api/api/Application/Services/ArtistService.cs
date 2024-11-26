using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using AutoMapper;
using framework.Application.Services;
using framework.Domain.Persistence;

namespace api.Application.Services;

public class ArtistService : GenericService<Artist, ArtistDto>, IArtistService
{
    public ArtistService(IArtistRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}