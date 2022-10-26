using MediatR;
using OutPoint.Application.DTOs.User;

namespace OutPoint.Application.Features.UserFeature.Queries;

public class UserGetAllQuery : IRequest<IEnumerable<UserDtoQuery>>
{
}