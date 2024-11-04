using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Domain.Entities;

namespace Ridel.Application.Services
{
    public class VehicleFeatureService : IVehicleFeatureService
    {
        private readonly IUnitOfWork _uow;

        public VehicleFeatureService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<VehicleFeature> AddVehicleFeatureAsync(VehicleFeature vehicleFeature)
        {
            await _uow.VehicleFeatureRepository.AddAsync(vehicleFeature);
            int isCreated = await _uow.CompleteAsync();

            if (isCreated == 1) return vehicleFeature;

            return new();
        }

        public async Task<bool> DeleteAsync(Guid vehicleFeatureId)
        {
            VehicleFeature? vehicleFeature = await _uow.VehicleFeatureRepository.GetAsync(t => t.Id == vehicleFeatureId);
            await _uow.VehicleFeatureRepository.DeleteAsync(vehicleFeature);
            int isDeleted = await _uow.CompleteAsync();
            return isDeleted == 1 ? true : false;
        }

        public async Task<IEnumerable<VehicleFeature>> GetAllAsync()
        {
            return await _uow.VehicleFeatureRepository.GetAllAsync();
        }

        public async Task<int> UpdateVehicleFeatureAsync(VehicleFeature vehicleFeatureRequest)
        {
            // Mevcut VehicleType'ı veritabanından alın
            VehicleFeature existingVehicleFeautre = await _uow.VehicleFeatureRepository.GetAsync(vehicleFeature => vehicleFeature.Id == vehicleFeatureRequest.Id);

            if (existingVehicleFeautre == null)
                return 0;


            // Güncelleme isteğiyle gelen bilgilerle güncelleme yapın
            existingVehicleFeautre.FeatureName = vehicleFeatureRequest.FeatureName;
            existingVehicleFeautre.Description = vehicleFeatureRequest.Description;
            existingVehicleFeautre.IsDeleted = vehicleFeatureRequest.IsDeleted;


            await _uow.VehicleFeatureRepository.UpdateAsync(existingVehicleFeautre);

            return await _uow.CompleteAsync();
        }
    }
}
