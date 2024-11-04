using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class UpdateVehicleFeatureCommandHandler : IRequestHandler<UpdateVehicleFeatureCommand, RidelResponse<string>>
    {
        private readonly IVehicleFeatureService _vehicleFeatureService;
        private readonly IMapper _mapper;
        public UpdateVehicleFeatureCommandHandler(IVehicleFeatureService vehicleFeatureService, IMapper mapper)
        {
            _vehicleFeatureService = vehicleFeatureService;
            _mapper = mapper;
        }

        public async Task<RidelResponse<string>> Handle(UpdateVehicleFeatureCommand request, CancellationToken cancellationToken)
        {
            VehicleFeature vehicleFeature = _mapper.Map<VehicleFeature>(request);
            int isUpdated = await _vehicleFeatureService.UpdateVehicleFeatureAsync(vehicleFeature);

            return new RidelResponse<string>(vehicleFeature.FeatureName, "Vehicle feature update successfully.");
        }
    }
}
