using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Queries.Vehicles;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class GetAllVehicleFeaturesQueryHandler : IRequestHandler<GetAllVehicleFeaturesQuery, RidelResponse<IEnumerable<VehicleFeatureDTO>>>
    {
        private readonly IVehicleFeatureService _vehicleFeatureService;
        private readonly IMapper _mapper;
        public GetAllVehicleFeaturesQueryHandler(IVehicleFeatureService vehicleFeatureService, IMapper mapper)
        {
            _vehicleFeatureService = vehicleFeatureService;
            _mapper = mapper;
        }

        async Task<RidelResponse<IEnumerable<VehicleFeatureDTO>>> IRequestHandler<GetAllVehicleFeaturesQuery, RidelResponse<IEnumerable<VehicleFeatureDTO>>>.Handle(GetAllVehicleFeaturesQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<VehicleFeature>? vehicleTypes = await _vehicleFeatureService.GetAllAsync();

            if (vehicleTypes == null)
                return new RidelResponse<IEnumerable<VehicleFeatureDTO>>(new List<VehicleFeatureDTO>());



            IEnumerable<VehicleFeatureDTO> vehicleTypeList = vehicleTypes.Select(vehicleType => _mapper.Map<VehicleFeatureDTO>(vehicleType));

            return new RidelResponse<IEnumerable<VehicleFeatureDTO>>(vehicleTypeList);
        }
    }
}
