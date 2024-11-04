using Ridel.Application.CQRS.Commands.Vehicles;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Interfaces;
using Ridel.Application.Wrappers;
using Ridel.Domain.Entities;
using MediatR;

namespace Ridel.Application.CQRS.Handlers.Vehicles
{
    public class DeleteVehicleFeatureCommandHandler : IRequestHandler<DeleteVehicleFeatureCommand, RidelResponse<string>>
    {
        private readonly IVehicleFeatureService _vehicleFeatureService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleFeatureCommandHandler(IVehicleFeatureService vehicleFeatureService, IUnitOfWork unitOfWork)
        {
            _vehicleFeatureService = vehicleFeatureService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RidelResponse<string>> Handle(DeleteVehicleFeatureCommand request, CancellationToken cancellationToken)
        {
            VehicleFeature vehicleFeature = await _unitOfWork.VehicleFeatureRepository.GetAsync(t => t.Id == request.Id);
            if (vehicleFeature is null)
                return new RidelResponse<string>("Vehicle feature not found.");

            // daha önce IsDeleted True olmuş ise ikinci kez hard delete için gelmiş demektir.
            if (vehicleFeature.IsDeleted)
            {
                await _vehicleFeatureService.DeleteAsync(request.Id);
                return new RidelResponse<string>(vehicleFeature.FeatureName, "Vehicle Feature is hard delete successfully.");
            }

            // eğer ilk kez geliyor ise soft delete yapacağız.
            vehicleFeature.IsDeleted = true;
            await _vehicleFeatureService.UpdateVehicleFeatureAsync(vehicleFeature);


            return new RidelResponse<string>(vehicleFeature.FeatureName, "Vehicle Feature delete successfully.");
        }
    }
}
