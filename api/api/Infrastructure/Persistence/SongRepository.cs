using api.Application;
using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using framework.Application;
using framework.Infrastructure.Persistence;
using framework.Infrastructure.Specs;
using System.Linq;

namespace api.Infrastructure.Persistence
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly KreitekfyContext _context;
        private readonly ISpecificationParser<Song> _specificationParser;

        public SongRepository(KreitekfyContext context, ISpecificationParser<Song> specificationParser) : base(context)
        {
            _context = context;
            _specificationParser = specificationParser;
        }

        public PagedList<SongDto> GetSongsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var songs = _context.Songs.AsQueryable();

            // Aplica el filtro de género si se proporciona
            songs = SongFilters.ApplyFilter(songs, filter, _specificationParser);

            // Aplica ordenamiento si se proporciona
            if (!string.IsNullOrEmpty(paginationParameters.Sort))
            {
                songs = ApplySortOrder(songs, paginationParameters.Sort);
            }

            // Proyección de las canciones a DTOs
            var songsDto = songs.Select(i => new SongDto()
            {
                Id = i.Id,
                Title = i.Title,
                Album = i.Album,
                Artist = i.Artist,
                AlbumCover = i.AlbumCover,
                Genre = i.Genre,
                Duration = $"{i.Duration.Minutes:D2}:{i.Duration.Seconds:D2}",
                Streams = i.Streams,
                Rating = i.Rating,
                AddedAt = i.AddedAt
            });

            // Devuelve los resultados paginados
            return PagedList<SongDto>.ToPagedList(songsDto, paginationParameters.PageNumber, paginationParameters.PageSize);
        }
    }
}