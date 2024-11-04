using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ridel.Application.CQRS.Commands.Authentication;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Interfaces;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
 

namespace Ridel.Application.CQRS.Handlers.Authentication
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserCommand, RidelResponse<LoginResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public LoginUserQueryHandler(UserManager<User> userManager, IJwtService jwtService, IMapper mapper, IUnitOfWork uow, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
            _uow = uow;
            _signInManager = signInManager;
        }

        public async Task<RidelResponse<LoginResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            //var user = await _uow.UserRepository.GetAsync(t => t.Email ==  request.LoginRequest.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new RidelResponse<LoginResponse>("User Not Found.");
            }

            var token = _jwtService.GenerateJwtToken(user);

            //SignInResult? result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            
            return new RidelResponse<LoginResponse>(new LoginResponse
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(_jwtService.GetJwtSettings().ExpirationInMinutes),
                Role = user.Role.ToString()
            }, "User login successfully.");

            
        }
    }
}
