using MediatR;
using Ridel.Application.Wrappers;

namespace Ridel.Application.CQRS.Commands.Users
{
    public record class UpdateUserDetailCommand(
        string? CompanyName, 
        string? EIN, 
        string? CompanyAddress,
        string? ContactPerson, 
        string? CompanyPhoneNumber, 
        string? CompanyEmail, 
        DateTime? BirthDate, 
        string? WorkRegion) : IRequest<RidelResponse<string>>;
     
}
