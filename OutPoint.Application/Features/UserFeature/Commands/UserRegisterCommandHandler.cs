using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OutPoint.Application.Interfaces;
using OutPoint.Application.Responses;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Features.UserFeature.Commands;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, BaseCommandResponse>
{
    private readonly IOutPointIdentityDbContext _identityDbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<ApiUser> _userManager;

    public UserRegisterCommandHandler(IOutPointIdentityDbContext identityDbContext, IMapper mapper, UserManager<ApiUser> userManager)
    {
        _identityDbContext = identityDbContext;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<BaseCommandResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var user = _mapper.Map<ApiUser>(request);
        user.UserName = $"{request.FirstName} {request.LastName}";
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            response.Success = false;
            response.Message = "Incorrect data. Please try again.";
            response.Errors = result.Errors.Select(e => e.Description).ToList();

            return response;
        }

        await _userManager.AddToRoleAsync(user, "User");
        response.Message = "Created Successfully";
        
        return response;
    }
}