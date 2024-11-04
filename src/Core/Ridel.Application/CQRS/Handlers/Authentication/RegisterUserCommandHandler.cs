using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ridel.Application.CQRS.Commands.Authentication;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Interfaces;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
using Ridel.Domain.Enums;

namespace Ridel.Application.CQRS.Handlers.Authentication
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RidelResponse<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RidelResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (CheckAdminRole(request.RegisterRequest.Role))
                return new RidelResponse<string>("Standard users can only create Driver or Dispatcher users.");


            User? user = _mapper.Map<User>(request.RegisterRequest);

            IdentityResult? result = await _userManager.CreateAsync(user, request.RegisterRequest.Password);

            if (!result.Succeeded)
            {
                // IdentityResult'tan gelen hataları listeye çevir ve Response'a ekle
                var errors = result.Errors.Select(e => e.Description).ToList();

                return new RidelResponse<string>
                {
                    Succeeded = false,
                    Message = "User creation failed.",
                    Errors = errors
                };
            }

          
            await _userManager.AddToRoleAsync(user, request.RegisterRequest.Role.ToString());

            return new RidelResponse<string>(user.Id, "User registration successfully.");
        }

        private bool CheckAdminRole(UserRoles userRole)
        {
            if (userRole.Equals(UserRoles.Admin))
                return true;

            return false;
        }
    }
}
