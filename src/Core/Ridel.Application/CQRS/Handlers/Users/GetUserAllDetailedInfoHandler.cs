using MediatR;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Users
{
    public class GetUserAllDetailedInfoHandler : IRequestHandler<GetUserAllDetailedInfoQuery, RidelResponse<User>>
    {
        private readonly IUserService _userService;
        private readonly IUserClaimService _userClaimService;

        public GetUserAllDetailedInfoHandler(IUserService userService, IUserClaimService userClaimService)
        {
            _userService = userService;
            _userClaimService = userClaimService;
        }

        public async Task<RidelResponse<User>> Handle(GetUserAllDetailedInfoQuery request, CancellationToken cancellationToken)
        {
            string? userId = await _userClaimService.GetCurrentUserIdAsync();
            User? user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");

            return new RidelResponse<User>(user);

        }
    }
}
