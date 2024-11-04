using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.CQRS.Queries.Vehicles;
using Ridel.Application.DTOs.User;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BackOfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BackOfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

 
        [HttpGet("User/GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> GetAllUsers()
        {
            RidelResponse<IEnumerable<UserInfoDTO>>? users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

      
    }
}
