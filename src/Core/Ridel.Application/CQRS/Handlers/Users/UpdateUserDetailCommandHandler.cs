using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ridel.Application.CQRS.Commands.Users;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Users
{
    public class UpdateUserDetailCommandHandler : IRequestHandler<UpdateUserDetailCommand, RidelResponse<string>>
    {
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserClaimService _userClaimService;

        public UpdateUserDetailCommandHandler(IUserService userService, IUnitOfWork uow, IMapper mapper, IUserClaimService userClaimService, IUserDetailService userDetailService)
        {
            _userService = userService;
            _uow = uow;
            _mapper = mapper;
            _userClaimService = userClaimService;
            _userDetailService = userDetailService;
        }

        public async Task<RidelResponse<string>> Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
        {
            UserDetail userDetail = _mapper.Map<UserDetail>(request);
            userDetail.UserId = _userClaimService.GetCurrentUserIdAsync().Result;

            int isOk = await _userDetailService.UpsertAsync(userDetail);

            if (isOk == 0) { return new RidelResponse<string>("User details update failed."); }

            return new RidelResponse<string>("User details update successfully", "");

        }
    }
}
