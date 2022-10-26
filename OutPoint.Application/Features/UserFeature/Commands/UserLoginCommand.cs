using System.ComponentModel.DataAnnotations;
using MediatR;
using OutPoint.Application.Responses;

namespace OutPoint.Application.Features.UserFeature.Commands;

public class UserLoginCommand : IRequest<BaseCommandResponse>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}