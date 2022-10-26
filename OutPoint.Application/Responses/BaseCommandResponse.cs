using MediatR;

namespace OutPoint.Application.Responses;

public class BaseCommandResponse : IRequest<Unit>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
}