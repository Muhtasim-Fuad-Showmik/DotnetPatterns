using AutoMapper;
using DotnetPatterns.Entities.DbSet;
using DotnetPatterns.Entities.Dtos.Requests;

namespace DotnetPatterns.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
            .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        
        CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
    }
}