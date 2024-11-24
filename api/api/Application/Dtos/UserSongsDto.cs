using framework.Application.Dtos;

namespace api.Application.Dtos;

public class UserSongsDto : IDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long SongId { get; set; }
    public DateTime PlayedAt { get; set; }
}