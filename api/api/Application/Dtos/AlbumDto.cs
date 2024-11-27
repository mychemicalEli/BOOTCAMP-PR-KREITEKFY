using framework.Application.Dtos;

namespace api.Application.Dtos;

public class AlbumDto : IDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public byte[] Cover { get; set; }

}