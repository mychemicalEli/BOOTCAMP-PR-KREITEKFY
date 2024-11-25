namespace api.Application
{
    using Domain.Entities;
    using Domain.Enums;
    using System;
    using System.Linq;
    using framework.Infrastructure.Specs;

    public class SongFilters
    {
        public static IQueryable<Song> ApplyFilter(IQueryable<Song> songs, string? filter, ISpecificationParser<Song> specificationParser)
        {
            if (string.IsNullOrEmpty(filter))
                return songs;

            var parts = filter.Split(":");
            
            // Filtrado por género si el filtro tiene la forma "genre:match"
            if (parts.Length == 3 && parts[0] == "genre" && parts[1] == "match")
            {
                var genreSearchTerm = parts[2].Trim().ToLower();

                // Obtener géneros que coincidan con el término de búsqueda (búsqueda parcial)
                var matchingGenres = Enum.GetValues<Genres>()
                    .Where(g => g.ToString().ToLower()
                        .Contains(genreSearchTerm)) 
                    .ToList();

                // Si hay géneros coincidentes, filtrar las canciones por esos géneros
                if (matchingGenres.Any())
                {
                    songs = songs.Where(s => matchingGenres.Contains(s.Genre));
                }
                else
                {
                    // Si no hay géneros coincidentes, devolver una consulta vacía
                    return songs.Where(s => false);
                }
            }
            else
            {
                // Si no es un filtro de género, aplicar una especificación
                Specification<Song> specification = specificationParser.ParseSpecification(filter);
                songs = specification.ApplySpecification(songs);
            }

            return songs;
        }
    }
}