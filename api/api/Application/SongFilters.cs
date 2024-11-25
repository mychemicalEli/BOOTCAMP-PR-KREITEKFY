using api.Domain.Entities;

namespace api.Application
{
    using Domain.Entities;
    using Domain.Enums;
    using System;
    using System.Linq;
    using framework.Infrastructure.Specs;

    public class SongFilters
    {
        public static IQueryable<Song> ApplyFilter(IQueryable<Song> songs, string? filter,
            ISpecificationParser<Song> specificationParser)
        {
            if (string.IsNullOrEmpty(filter))
                return songs;

            var parts = filter.Split(":");

            if (parts.Length == 3 && parts[0] == "genre" && parts[1] == "match")
            {
                var genreSearchTerm = parts[2].Trim().ToLower();

                var matchingGenres = Enum.GetValues<Genres>()
                    .Where(g => g.ToString().ToLower()
                        .Contains(genreSearchTerm))
                    .ToList();

                if (matchingGenres.Any())
                {
                    songs = songs.Where(s => matchingGenres.Contains(s.Genre));
                }
                else
                {
                    return songs.Where(s => false);
                }
            }
            else
            {
                Specification<Song> specification = specificationParser.ParseSpecification(filter);
                songs = specification.ApplySpecification(songs);
            }

            return songs;
        }
    }
}