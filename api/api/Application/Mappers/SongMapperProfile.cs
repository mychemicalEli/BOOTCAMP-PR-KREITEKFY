using api.Application.Dtos;
using api.Domain.Entities;
using api.Domain.Enums;
using AutoMapper;

namespace api.Application.Mappers;

public class SongMapperProfile : Profile
{
    public SongMapperProfile()
    {
        CreateMap<Song, SongDto>()
            .ForMember(dest => dest.Duration,
                opt => opt.MapFrom(src => TimeSpanConverter.ToString(src.Duration)));

        CreateMap<SongDto, Song>()
            .ForMember(dest => dest.Duration,
                opt => opt.MapFrom(src => TimeSpanConverter.ToTimeSpan(src.Duration)));
    }
}