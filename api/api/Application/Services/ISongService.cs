using api.Application.Dtos;
using framework.Application;
using framework.Application.Services;

namespace api.Application.Services;

public interface ISongService:IGenericService<SongDto>
{
    PagedList<SongDto> GetSongsByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
}