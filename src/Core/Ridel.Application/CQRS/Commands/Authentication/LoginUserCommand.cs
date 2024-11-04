using MediatR;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.CQRS.Commands.Authentication
{
    public class LoginUserCommand : IRequest<RidelResponse<LoginResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
