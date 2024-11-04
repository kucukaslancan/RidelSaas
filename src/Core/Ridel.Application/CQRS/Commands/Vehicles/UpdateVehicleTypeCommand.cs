using MediatR;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.Wrappers;
using System.ComponentModel.DataAnnotations;

namespace Ridel.Application.CQRS.Commands.Vehicles
{
    public class UpdateVehicleTypeCommand : IRequest<RidelResponse<string>>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
