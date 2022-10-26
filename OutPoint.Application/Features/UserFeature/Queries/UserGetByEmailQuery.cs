using System.ComponentModel.DataAnnotations;
using MediatR;
using OutPoint.Application.DTOs.User;

namespace OutPoint.Application.Features.UserFeature.Queries;

public class UserGetByEmailQuery : IRequest<UserDtoQuery>
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}