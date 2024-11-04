using MediatR;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Wrappers;

namespace Ridel.Application.CQRS.Queries.Vehicles
{
    public class GetAllVehicleFeaturesQuery : IRequest<RidelResponse<IEnumerable<VehicleFeatureDTO>>>
    {
    }
}
