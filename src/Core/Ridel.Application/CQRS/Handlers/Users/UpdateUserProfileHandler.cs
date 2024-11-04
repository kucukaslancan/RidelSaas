using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Users;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Users
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, RidelResponse<string>>
    {
        private readonly IUserService _userService;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly IUserClaimService _userClaimService;

        public UpdateUserProfileHandler(IStorageService storageService, IMapper mapper, IUserService userService, IUserClaimService userClaimService)
        {
            _storageService = storageService;
            _mapper = mapper;
            _userService = userService;
            _userClaimService = userClaimService;
        }

        public async Task<RidelResponse<string>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
           
            string? userId = await _userClaimService.GetCurrentUserIdAsync();
            User? user = await _userService.GetUserByIdAsync(userId);

            user = _mapper.Map(request, user);

           
            if (request.ProfilePhoto != null)
            {
              
                if (!string.IsNullOrWhiteSpace(user?.ProfilePhotoUrl))
                {
                    await _storageService.DeleteFileAsync(user.ProfilePhotoUrl);
                }

              
                var photoUrl = await _storageService.UploadFileAsync(request.ProfilePhoto, user.Id);
                user.ProfilePhotoUrl = photoUrl; 
            }

         
            await _userService.UpdateUserAsync(user);

            return new RidelResponse<string>(user?.UserName,"User profile updated.");
        }
    }
}
