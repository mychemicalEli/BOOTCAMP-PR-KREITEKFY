using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using AutoMapper;
using framework.Application;
using framework.Application.Services;
using framework.Domain.Persistence;
using IImageVerifier = api.Domain.Services.IImageVerifier;
using InvalidImageException = api.Domain.Services.InvalidImageException;

namespace api.Application.Services;

public class SongService : GenericService<Song, SongDto>, ISongService
{
    private readonly ISongRepository _repository;
    private readonly IImageVerifier _imageVerifier;

    public SongService(ISongRepository repository, IMapper mapper, IImageVerifier imageVerifier) : base(repository,
        mapper)
    {
        _repository = repository;
        _imageVerifier = imageVerifier;
    }

    public PagedList<SongDto> GetSongsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
    {
        var songs = _repository.GetSongsByCriteriaPaged(filter, paginationParameters);
        return songs;
    }

    public override SongDto Insert(SongDto dto)
    {
        if (!_imageVerifier.IsImage(dto.AlbumCover))
            throw new InvalidImageException();
        return base.Insert(dto);
    }
    
    public override SongDto Update(SongDto dto)
    {
        if (!_imageVerifier.IsImage(dto.AlbumCover))
            throw new InvalidImageException();
        return base.Update(dto);
    }
}