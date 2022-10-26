using System.ComponentModel.DataAnnotations;
using MediatR;
using OutPoint.Application.Responses;

namespace OutPoint.Application.Features.UserFeature.Commands;

public class UserRegisterCommand : IRequest<BaseCommandResponse>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = string.Empty;
}