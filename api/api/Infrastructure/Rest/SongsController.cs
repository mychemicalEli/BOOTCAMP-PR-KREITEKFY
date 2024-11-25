using api.Application.Dtos;
using api.Application.Services;
using api.Domain.Enums;
using framework.Application;
using framework.Domain.Persistence;
using framework.Infrastructure.Rest;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Rest;

[Route("api/[controller]")]
[ApiController]
public class SongsController : GenericCrudController<SongDto>
{
    private ISongService _service;
    private readonly ILogger<SongsController> _logger;

    public SongsController(ISongService service, ILogger<SongsController> logger) : base(service)
    {
        _service = service;
        _logger = logger;
    }

    [NonAction]
    public override ActionResult<IEnumerable<SongDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Produces("application/json")]
    public ActionResult<PagedResponse<SongDto>> Get([FromQuery] string? filter,
        [FromQuery] PaginationParameters paginationParameters)
    {
        try
        {
            PagedList<SongDto> page = _service.GetSongsByCriteriaPaged(filter, paginationParameters);
            var response = new PagedResponse<SongDto>
            {
                CurrentPage = page.CurrentPage,
                TotalPages = page.TotalPages,
                PageSize = page.PageSize,
                TotalCount = page.TotalCount,
                Data = page
            };
            return Ok(response);
        }
        catch (MalformedFilterException)
        {
            return BadRequest();
        }
    }

    public override ActionResult<SongDto> Insert(SongDto dto)
    {
        try
        {
            return base.Insert(dto);
        }
        catch (InvalidImageException)
        {
            _logger.LogInformation("Invalid image inserting song with {dto.title}", dto.Title);
            return BadRequest();
        }
    }
    
    public override ActionResult<SongDto> Update(SongDto dto)
    {
        try
        {
            return base.Update(dto);
        }
        catch (InvalidImageException)
        {
            _logger.LogInformation("Invalid image updating song with {dto.title}", dto.Title);
            return BadRequest();
        }
    }
    
    [HttpGet("latest")]
    [Produces("application/json")]
    public ActionResult<IEnumerable<SongDto>> GetLatestSongs([FromQuery] int count = 5, [FromQuery] Genres? genre = null)
    {
        try
        {
            var songs = _service.GetLatestSongs(count, genre);
            return Ok(songs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching latest songs.");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpGet("mostPlayed")]
    [Produces("application/json")]
    public ActionResult<IEnumerable<SongDto>> GetMostPlayedSongs([FromQuery] int count = 5, [FromQuery] Genres? genre = null)
    {
        try
        {
            var songs = _service.GetMostPlayedSongs(count, genre);
            return Ok(songs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching latest songs.");
            return StatusCode(500, "Internal server error");
        }
    }

}