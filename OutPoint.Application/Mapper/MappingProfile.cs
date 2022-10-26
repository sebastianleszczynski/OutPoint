using AutoMapper;
using OutPoint.Application.DTOs.User;
using OutPoint.Application.Features.UserFeature.Commands;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApiUser, UserDtoQuery>().ReverseMap();
        CreateMap<ApiUser, UserRegisterCommand>().ReverseMap();
    }
}