using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.DTOs.User;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, RidelResponse<IEnumerable<UserInfoDTO>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        async Task<RidelResponse<IEnumerable<UserInfoDTO>>> IRequestHandler<GetAllUsersQuery, RidelResponse<IEnumerable<UserInfoDTO>>>.Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User>? users = await _userService.GetAllUsersAsync();

            if (users == null)
                return new RidelResponse<IEnumerable<UserInfoDTO>>(new List<UserInfoDTO>());

            var userList = users.Select(user => _mapper.Map<UserInfoDTO>(user));

            return new RidelResponse<IEnumerable<UserInfoDTO>>(userList);
        }
    }
}
