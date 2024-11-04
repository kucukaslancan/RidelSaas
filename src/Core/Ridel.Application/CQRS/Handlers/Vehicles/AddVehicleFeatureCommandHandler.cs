using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class AddVehicleFeatureCommandHandler : IRequestHandler<AddVehicleFeatureCommand, RidelResponse<VehicleFeatureDTO>>
    {
        IVehicleFeatureService _vehicleFeatureService;
        private readonly IMapper _mapper;

        public AddVehicleFeatureCommandHandler(IVehicleFeatureService vehicleFeatureService, IMapper mapper)
        {
            _vehicleFeatureService = vehicleFeatureService;
            _mapper = mapper;
        }

        public async Task<RidelResponse<VehicleFeatureDTO>> Handle(AddVehicleFeatureCommand request, CancellationToken cancellationToken)
        {
            VehicleFeature vehicleFeature = _mapper.Map<VehicleFeature>(request);

            vehicleFeature = await _vehicleFeatureService.AddVehicleFeatureAsync(vehicleFeature);

            if (vehicleFeature != null && !string.IsNullOrEmpty(vehicleFeature.Id.ToString()))
            {
                VehicleFeatureDTO vehicleFeatureDTO = _mapper.Map<VehicleFeatureDTO>(vehicleFeature);
                return new RidelResponse<VehicleFeatureDTO>(vehicleFeatureDTO, "Vehicle feature is created successfully.");
            }

            return new RidelResponse<VehicleFeatureDTO>("Error: Vehicle feature creation failed.");
        }
    }
}
