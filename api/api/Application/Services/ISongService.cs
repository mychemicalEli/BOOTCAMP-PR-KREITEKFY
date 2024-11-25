using api.Application.Dtos;
using api.Domain.Enums;
using framework.Application;
using framework.Application.Services;

namespace api.Application.Services;

public interface ISongService:IGenericService<SongDto>
{
    PagedList<SongDto> GetSongsByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    IEnumerable<SongDto> GetLatestSongs(int count = 5, Genres? genre = null);
    IEnumerable<SongDto> GetMostPlayedSongs(int count = 5, Genres? genre = null);
}