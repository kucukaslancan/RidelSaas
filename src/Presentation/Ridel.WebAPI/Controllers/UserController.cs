using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ridel.Application.CQRS.Commands.Users;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.DTOs.User;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
using Ridel.Domain.Enums;

namespace Ridel.WebAPI.Controllers
{
    [Authorize(Roles = "Driver,Dispatcher,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        private readonly IUserClaimService _userClaimService;

        public UserController(IUserService userService, IMediator mediator, IUserClaimService userClaimService)
        {
            _userService = userService;
            _mediator = mediator;
            _userClaimService = userClaimService;
        }

        [HttpGet]
        public async Task<ActionResult<UserInfoDTO>> GetUser()
        {
            RidelResponse<UserInfoDTO>? userInfo = await _mediator.Send(new GetUserInfoQuery());

            return Ok(userInfo);
        }

        

        [HttpGet("GetUserAllDetailedInfo")]
        public async Task<ActionResult<User>> GetUserAllDetails()
        {
           RidelResponse<User>? user = await _mediator.Send(new GetUserAllDetailedInfoQuery());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPatch("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateUserProfileCommand profileUpdateDto)
        {
            RidelResponse<string>? userProfileUpdateResult = await _mediator.Send(profileUpdateDto);
            return Ok(userProfileUpdateResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpPatch("details")]
        public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserDetailCommand userDetails)
        {
            RidelResponse<string>? updateResult = await _mediator.Send(userDetails);
            //await _userService.UpdateUserDetailsAsync(userDetails);
            return Ok(updateResult);
        }

        [HttpGet("has-details")]
        public async Task<IActionResult> HasUserDetails()
        {
            var hasDetails = await _userService.HasUserDetailsAsync();
            return Ok(new { hasDetails });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
