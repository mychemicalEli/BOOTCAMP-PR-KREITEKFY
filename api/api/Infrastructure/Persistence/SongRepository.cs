using api.Application;
using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using framework.Application;
using framework.Infrastructure.Persistence;
using framework.Infrastructure.Specs;
using System.Linq;
using api.Domain.Enums;

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

            songs = SongFilters.ApplyFilter(songs, filter, _specificationParser);

            if (!string.IsNullOrEmpty(paginationParameters.Sort))
            {
                songs = ApplySortOrder(songs, paginationParameters.Sort);
            }

            var songsDto = songs.Select(i => new SongDto()
            {
                Id = i.Id,
                Title = i.Title,
                Album = i.Album,
                Artist = i.Artist,
                AlbumCover = i.AlbumCover,
                Genre = i.Genre,
                Duration = TimeSpanConverter.ToString(i.Duration),
                Streams = i.Streams,
                Rating = i.Rating,
                AddedAt = i.AddedAt
            });

            return PagedList<SongDto>.ToPagedList(songsDto, paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }


        public IEnumerable<SongDto> GetLatestSongs(int count = 5, Genres? genre = null)
        {
            var songs = _context.Songs
                .Where(song => !genre.HasValue || song.Genre == genre)
                .OrderByDescending(song => song.AddedAt) 
                .Take(count) 
                .Select(i => new SongDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    Album = i.Album,
                    Artist = i.Artist,
                    AlbumCover = i.AlbumCover,
                    Genre = i.Genre,
                    Duration = TimeSpanConverter.ToString(i.Duration),
                    Streams = i.Streams,
                    Rating = i.Rating,
                    AddedAt = i.AddedAt
                });

            return songs;
        }

    }
}