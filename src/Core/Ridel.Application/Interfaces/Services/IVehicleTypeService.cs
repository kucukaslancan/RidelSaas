using Ridel.Application.DTOs.Vehicle;
using Ridel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.Interfaces.Services
{
    public interface IVehicleTypeService
    {
        Task<int> AddVehicleTypeAsync(VehicleType vehicleType);
        Task<int> UpdateVehicleTypeAsync(VehicleType vehicleType);
        Task<IEnumerable<VehicleType>> GetAllAsync();
        Task<bool> DeleteAsync(Guid vehicleTypeId);
    }
}
