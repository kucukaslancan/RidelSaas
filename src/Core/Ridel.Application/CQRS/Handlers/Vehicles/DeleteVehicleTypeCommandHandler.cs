using AutoMapper;
using MediatR;
using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand, RidelResponse<string>>
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleTypeCommandHandler(IVehicleTypeService vehicleTypeService, IUnitOfWork unitOfWork)
        {
            _vehicleTypeService = vehicleTypeService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RidelResponse<string>> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType vehicleType = await _unitOfWork.VehicleTypeRepository.GetAsync(t => t.Id == request.Id);
            if(vehicleType is null)
                return new RidelResponse<string>( "Vehicle type not found.");

            // daha önce IsDeleted True olmuş ise ikinci kez hard delete için gelmiş demektir.
            if (vehicleType.IsDeleted)
            {
                await _vehicleTypeService.DeleteAsync(request.Id);
                return new RidelResponse<string>(vehicleType.Name, "Vehicle type is hard delete successfully.");
            }

            // eğer ilk kez geliyor ise soft delete yapacağız.
            vehicleType.IsDeleted = true;
            await _vehicleTypeService.UpdateVehicleTypeAsync(vehicleType);
            

            return new RidelResponse<string>(vehicleType.Name, "Vehicle type delete successfully.");
        }
    }
}
