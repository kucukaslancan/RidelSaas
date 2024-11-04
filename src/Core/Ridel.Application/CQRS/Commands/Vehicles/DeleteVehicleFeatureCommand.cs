using MediatR;
using Ridel.Application.Wrappers;

namespace Ridel.Application.CQRS.Commands.Vehicles
{
    public class DeleteVehicleFeatureCommand : IRequest<RidelResponse<string>>
    {
        public Guid Id { get; set; }
    }
}
