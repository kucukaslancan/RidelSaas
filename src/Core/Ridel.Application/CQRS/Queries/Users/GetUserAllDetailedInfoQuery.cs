using MediatR;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Queries.Users
{
    public class GetUserAllDetailedInfoQuery : IRequest<RidelResponse<User>>
    {
    }
}
