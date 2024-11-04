using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ridel.Application.CQRS.Commands.Authentication;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Wrappers;

namespace Ridel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterUserCommand(request);
            RidelResponse<string>? registerResult = await _mediator.Send(command);
            return Ok(registerResult);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
        {
            RidelResponse<LoginResponse>? response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
