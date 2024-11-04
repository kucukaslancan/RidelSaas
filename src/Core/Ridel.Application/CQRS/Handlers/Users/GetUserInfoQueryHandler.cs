using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.DTOs.User;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
using Ridel.Domain.Enums;

namespace Ridel.Application.CQRS.Handlers.Users
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, RidelResponse<UserInfoDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserClaimService _userClaimService;

        public GetUserInfoQueryHandler(IUserService userService, IMapper mapper, IUserClaimService userClaimService)
        {
            _userService = userService;
            _mapper = mapper;
            _userClaimService = userClaimService;
        }

        public async Task<RidelResponse<UserInfoDTO>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            string? userId = await _userClaimService.GetCurrentUserIdAsync();
            User? user = await _userService.GetUserByIdAsync(userId);

            UserInfoDTO? userInfo = _mapper.Map<UserInfoDTO>(user);
            userInfo.Role = Enum.GetName(typeof(UserRoles), (int)user.Role);

            return new RidelResponse<UserInfoDTO>(userInfo);
        }
    }
}
