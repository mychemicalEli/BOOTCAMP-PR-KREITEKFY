using framework.Application.Dtos;

namespace api.Application.Dtos;

public class SongDto : IDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public long AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string ArtistName { get; set; }
    
    public string AlbumCover { get; set; }
    public long GenreId { get; set; }
    public string GenreName { get; set; }
    public string Duration { get; set; }
    public decimal Rating { get; set; }
    public long Streams { get; set; }
    public DateTime AddedAt { get; set; }
}