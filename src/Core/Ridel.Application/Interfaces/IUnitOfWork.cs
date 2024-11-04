using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Tüm Repository'lerin tanımı
        IUserRepository UserRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IVehicleFeatureRepository VehicleFeatureRepository { get; }

        // Tüm değişiklikleri veritabanına kaydeder
        Task<int> CompleteAsync();
    }
}
