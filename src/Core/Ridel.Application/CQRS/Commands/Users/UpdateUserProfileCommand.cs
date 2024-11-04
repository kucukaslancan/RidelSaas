using MediatR;
using Microsoft.AspNetCore.Http;
using Ridel.Application.DTOs.User;
using Ridel.Application.Wrappers;

namespace Ridel.Application.CQRS.Commands.Users
{
    public record class UpdateUserProfileCommand(
        string? FirstName,
        string? LastName,
        string? Email,
        DateTime? BirthDate,
        IFormFile? ProfilePhoto,
        UserDetailDTO UserDetail) : IRequest<RidelResponse<string>>;



}
