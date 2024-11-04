using MediatR;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.CQRS.Queries.Vehicles
{
    public class GetAllVehicleTypesQuery : IRequest<RidelResponse<IEnumerable<VehicleTypeDTO>>>
    {
    }
}
