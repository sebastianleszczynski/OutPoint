using AutoMapper;
using OutPoint.Application.DTOs.User;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApiUser, UserDtoQuery>().ReverseMap();
    }
}