using api.Application.Dtos;
using api.Domain.Entities;
using AutoMapper;

namespace api.Application.Mappers;

public class AlbumMapperProfile : Profile
{
    public AlbumMapperProfile()
    {
        CreateMap<Album, AlbumDto>()
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name));
        CreateMap<AlbumDto, Album>();
    }
}