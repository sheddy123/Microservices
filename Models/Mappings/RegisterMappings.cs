using AutoMapper;
using PlatformService.Models.Dto;

namespace PlatformService.Models.Mappings;

public class RegisterMappings : Profile
{
    public RegisterMappings()
    {
        CreateMap<Platform, PlatformReadDto>().ReverseMap();
        CreateMap<Platform, PlatformCreateDto>().ReverseMap();
    }
}