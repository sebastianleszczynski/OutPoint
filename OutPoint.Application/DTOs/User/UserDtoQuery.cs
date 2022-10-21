using System.ComponentModel.DataAnnotations;

namespace OutPoint.Application.DTOs.User;

public class UserDtoQuery
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}