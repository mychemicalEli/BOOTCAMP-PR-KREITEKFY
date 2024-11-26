using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Persistence;
using framework.Domain.Persistence;
using framework.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
{
    private KreitekfyContext _context;

    public AlbumRepository(KreitekfyContext context) : base(context)
    {
        _context = context;
    }

    public List<AlbumDto> GetAllAlbumsWithArtistName()
    {
        return _context.Albums
            .Select(u => new AlbumDto
            {
                Id = u.Id,
                Title = u.Title,
                Cover = u.Cover,
                ArtistId = u.ArtistId,
                ArtistName = u.Artist.Name
            })
            .ToList();
    }


    public override Album GetById(long id)
    {
        var album = _context.Albums.Include(i => i.Artist).SingleOrDefault(i => i.Id == id);
        if (album == null)
        {
            throw new ElementNotFoundException();
        }

        return album;
    }

    public override Album Insert(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
        _context.Entry(album).Reference(i => i.Artist).Load();
        return album;
    }

    public override Album Update(Album album)
    {
        _context.Albums.Update(album);
        _context.SaveChanges();
        _context.Entry(album).Reference(i => i.Artist).Load();
        return album;
    }
}