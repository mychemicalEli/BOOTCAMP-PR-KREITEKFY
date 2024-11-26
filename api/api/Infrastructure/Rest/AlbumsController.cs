using api.Application.Dtos;
using api.Application.Services;
using api.Domain.Services;
using framework.Infrastructure.Rest;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Rest;
[Route("api/[controller]")]
[ApiController]
public class AlbumsController : GenericCrudController<AlbumDto>
{
    private readonly IAlbumService _service;
    private readonly ILogger<AlbumsController> _logger;

    public AlbumsController(IAlbumService service, ILogger<AlbumsController> logger) : base(service)
    {
        _service = service;
        _logger = logger;
    }

    [NonAction]
    public override ActionResult<IEnumerable<AlbumDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Produces("application/json")]
    public ActionResult<AlbumDto> GetAllAlbumsWithArtistName()
    {
        return Ok(_service.GetAllAlbumsWithArtistName());
    }
    
    public override ActionResult<AlbumDto> Insert(AlbumDto dto)
    {
        try
        {
            return base.Insert(dto);
        }
        catch (InvalidImageException)
        {
            _logger.LogInformation("Invalid image inserting album with {dto.Title} name", dto.Title);
            return BadRequest();
        }
    }

    public override ActionResult<AlbumDto> Update(AlbumDto dto)
    {
        try
        {
            return base.Update(dto);
        }
        catch (InvalidImageException)
        {
            _logger.LogInformation("Invalid image updating album with {dto.Id} ID", dto.Id);
            return BadRequest();
        }
    }
}