using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class AddVehicleTypeCommandHandler : IRequestHandler<AddVehicleTypeCommand, RidelResponse<string>>
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _mapper;

        public AddVehicleTypeCommandHandler(IVehicleTypeService vehicleTypeService, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
        }

        public async Task<RidelResponse<string>> Handle(AddVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType vehicleType = _mapper.Map<VehicleType>(request);

            int inserted = await _vehicleTypeService.AddVehicleTypeAsync(vehicleType);

            if (inserted > 0)
                return new RidelResponse<string>(vehicleType.Name, "Vehicle type is created");

            return new RidelResponse<string>("vehicle type insert error");
            
        }
    }
}
