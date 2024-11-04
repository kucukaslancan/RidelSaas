using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Queries.Users;
using Ridel.Application.CQRS.Queries.Vehicles;
using Ridel.Application.DTOs.User;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, RidelResponse<IEnumerable<VehicleTypeDTO>>>
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _mapper;
        public GetAllVehicleTypesQueryHandler(IVehicleTypeService vehicleTypeService, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
        }

        async Task<RidelResponse<IEnumerable<VehicleTypeDTO>>> IRequestHandler<GetAllVehicleTypesQuery, RidelResponse<IEnumerable<VehicleTypeDTO>>>.Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<VehicleType>? vehicleTypes = await _vehicleTypeService.GetAllAsync();

            if (vehicleTypes == null)
                return new RidelResponse<IEnumerable<VehicleTypeDTO>>(new List<VehicleTypeDTO>());

 

            IEnumerable<VehicleTypeDTO> vehicleTypeList = vehicleTypes.Select(vehicleType => _mapper.Map<VehicleTypeDTO>(vehicleType));

            return new RidelResponse<IEnumerable<VehicleTypeDTO>>(vehicleTypeList);
        }
    }
}
