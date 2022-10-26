using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OutPoint.Application.Responses;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Features.UserFeature.Commands;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, BaseCommandResponse>
{
    private readonly UserManager<ApiUser> _userManager;
    private readonly IConfiguration _configuration;

    public UserLoginCommandHandler(UserManager<ApiUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<BaseCommandResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var user = await _userManager.FindByEmailAsync(request.Email);
        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (user == null || passwordValid == false)
        {
            response.Success = false;
            response.Message = "Login failed.";
            response.Errors = new List<string>{"Username or password is incorrect. Please try again."};

            return response;
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ApiToken"]));
        var token = new JwtSecurityToken(  
            issuer: _configuration["JWT:ValidIssuer"],  
            audience: _configuration["JWT:ValidAudience"],  
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,  
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)  
        );

        response.Message = new JwtSecurityTokenHandler().WriteToken(token);
        await _userManager.SetAuthenticationTokenAsync(user, _configuration["JWT:ValidIssuer"], "Login", response.Message);

        return response;
    }
}