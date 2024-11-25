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
                opt => opt.MapFrom(src => TimeSpanToString(src.Duration)));

        CreateMap<SongDto, Song>()
            .ForMember(dest => dest.Duration,
                opt => opt.MapFrom(src => StringToTimeSpan(src.Duration)));
    }

    private string TimeSpanToString(TimeSpan duration)
    {
        return $"{duration.Minutes:D2}:{duration.Seconds:D2}";
    }

    private TimeSpan StringToTimeSpan(string duration)
    {
        var parts = duration.Split(':');
        var minutes = int.Parse(parts[0]);
        var seconds = int.Parse(parts[1]);
        return new TimeSpan(0, minutes, seconds);
    }
}