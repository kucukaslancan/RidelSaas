using MediatR;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Wrappers;

namespace Ridel.Application.CQRS.Commands.Authentication
{
    public class RegisterUserCommand : IRequest<RidelResponse<string>>
    {
        public RegisterRequest RegisterRequest { get; set; }

        public RegisterUserCommand(RegisterRequest registerRequest)
        {
            RegisterRequest = registerRequest;
        }
    }
}
