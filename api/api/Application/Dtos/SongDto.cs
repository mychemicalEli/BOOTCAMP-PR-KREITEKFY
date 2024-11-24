using api.Domain.Enums;
using framework.Application.Dtos;

namespace api.Application.Dtos;

public class SongDto:IDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public byte[] AlbumCover { get; set; }
    public Genres Genre { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Rating { get; set; }
    public long Streams { get; set; }
    public DateTime ReleaseDate { get; set; }
    public byte[] RowVersion { get; set; }
}