using MediatR;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Wrappers;
using System.ComponentModel.DataAnnotations;

namespace Ridel.Application.CQRS.Commands.Vehicles
{
    public class AddVehicleFeatureCommand:IRequest<RidelResponse<VehicleFeatureDTO>>
    {
        [Required(ErrorMessage = $"[{nameof(Name)}] value it cannot be left empty.")]
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
