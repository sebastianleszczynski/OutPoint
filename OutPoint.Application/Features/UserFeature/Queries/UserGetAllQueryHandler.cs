using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OutPoint.Application.DTOs.User;
using OutPoint.Application.Interfaces;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Features.UserFeature.Queries;

public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IEnumerable<UserDtoQuery>>
{
    private readonly IOutPointIdentityDbContext _identityDbContext;
    private readonly IMapper _mapper;

    public UserGetAllQueryHandler(IOutPointIdentityDbContext identityDbContext, IMapper mapper)
    {
        _identityDbContext = identityDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDtoQuery>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        var userListDb = await _identityDbContext.ApiUsers.ToListAsync();
        var userListDto = _mapper.Map<List<UserDtoQuery>>(userListDb);

        return userListDto.AsReadOnly();
    }
}