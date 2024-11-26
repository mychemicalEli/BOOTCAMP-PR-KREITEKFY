using api.Application.Dtos;
using framework.Application.Services;

namespace api.Application.Services;

public interface IAlbumService : IGenericService<AlbumDto>
{
    List<AlbumDto> GetAllAlbumsWithArtistName();
}