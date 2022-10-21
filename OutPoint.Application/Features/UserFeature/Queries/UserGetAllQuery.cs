using MediatR;
using OutPoint.Application.DTOs.User;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Features.UserFeature.Queries;

public class UserGetAllQuery : IRequest<IEnumerable<UserDtoQuery>>
{
}