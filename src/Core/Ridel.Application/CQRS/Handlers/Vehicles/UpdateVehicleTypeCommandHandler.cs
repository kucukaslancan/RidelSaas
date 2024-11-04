using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, RidelResponse<string>>
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _mapper;
        public UpdateVehicleTypeCommandHandler(IVehicleTypeService vehicleTypeService, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
        }

        public async Task<RidelResponse<string>> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType vehicleType = _mapper.Map<VehicleType>(request);
            int isUpdated = await _vehicleTypeService.UpdateVehicleTypeAsync(vehicleType);

            return new RidelResponse<string>(vehicleType.Name, "Vehicle type update successfully.");
        }
    }
}
