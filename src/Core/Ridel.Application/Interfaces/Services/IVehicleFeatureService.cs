using Ridel.Application.DTOs.Vehicle;
using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces.Services
{
    public interface IVehicleFeatureService
    {
        Task<VehicleFeature> AddVehicleFeatureAsync(VehicleFeature vehicleType);
        Task<int> UpdateVehicleFeatureAsync(VehicleFeature vehicleType);
        Task<IEnumerable<VehicleFeature>> GetAllAsync();
        Task<bool> DeleteAsync(Guid vehicleTypeId);
    }
}
