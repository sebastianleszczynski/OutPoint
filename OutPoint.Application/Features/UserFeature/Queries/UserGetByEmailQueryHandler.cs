using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OutPoint.Application.DTOs.User;
using OutPoint.Application.Interfaces;

namespace OutPoint.Application.Features.UserFeature.Queries;

public class UserGetByEmailQueryHandler : IRequestHandler<UserGetByEmailQuery, UserDtoQuery>
{
    private readonly IOutPointIdentityDbContext _identityDbContext;
    private readonly IMapper _mapper;

    public UserGetByEmailQueryHandler(IOutPointIdentityDbContext identityDbContext, IMapper mapper)
    {
        _identityDbContext = identityDbContext;
        _mapper = mapper;
    }

    public async Task<UserDtoQuery> Handle(UserGetByEmailQuery request, CancellationToken cancellationToken)
    {
        var userListDb = await _identityDbContext.ApiUsers.ToListAsync();
        var userDb = userListDb.FirstOrDefault(u => u.Email == request.Email);
        
        
        var userDto = _mapper.Map<UserDtoQuery>(userDb);

        return userDto;
    }
}