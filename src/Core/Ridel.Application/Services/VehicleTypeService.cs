using Ridel.Application.DTOs.Vehicle;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Domain.Entities;

namespace Ridel.Application.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork _uow;

        public VehicleTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> AddVehicleTypeAsync(VehicleType vehicleType)
        {
            await _uow.VehicleTypeRepository.AddAsync(vehicleType);
            int isCreated = await _uow.CompleteAsync();

            return isCreated;
        }

        public async Task<bool> DeleteAsync(Guid vehicleTypeId)
        {
            VehicleType? vehicleType = await _uow.VehicleTypeRepository.GetAsync(t => t.Id == vehicleTypeId);
            await _uow.VehicleTypeRepository.DeleteAsync(vehicleType);
            int isDeleted = await _uow.CompleteAsync();
            return isDeleted == 1 ? true : false;
        }

        public async Task<IEnumerable<VehicleType>> GetAllAsync()
        {
           return await _uow.VehicleTypeRepository.GetAllAsync();
        }

        public async Task<int> UpdateVehicleTypeAsync(VehicleType vehicleTypeRequest)
        {
            // Mevcut VehicleType'ı veritabanından alın
            VehicleType existingVehicleType = await _uow.VehicleTypeRepository.GetAsync(vehicleType => vehicleType.Id == vehicleTypeRequest.Id);

            if (existingVehicleType == null)
                return 0;
             

            // Güncelleme isteğiyle gelen bilgilerle güncelleme yapın
            existingVehicleType.Name = vehicleTypeRequest.Name;
            existingVehicleType.Description = vehicleTypeRequest.Description;
            existingVehicleType.IsDeleted = vehicleTypeRequest.IsDeleted;


            await _uow.VehicleTypeRepository.UpdateAsync(existingVehicleType);

            return await _uow.CompleteAsync();
        }
    }
}
