using MediatR;
using Ridel.Application.DTOs.User;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Queries.Users
{
    public class GetAllUsersQuery : IRequest<RidelResponse<IEnumerable<UserInfoDTO>>>
    {
    }
}
