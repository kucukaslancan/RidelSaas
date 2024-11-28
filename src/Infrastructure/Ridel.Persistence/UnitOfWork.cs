using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Persistence.Contexts;
using Ridel.Persistence.Repositories.Users;
using Ridel.Persistence.Repositories.Vehicle;

namespace Ridel.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Repositorylerin tanımı
        public IUserRepository User { get; private set; }
        public IUserDetailRepository UserDetail { get; private set; }
        public IVehicleTypeRepository VehicleType { get; private set; }
        public IVehicleFeatureRepository VehicleFeature { get; private set; }
        public IVehicleRepository Vehicle {  get; private set; }
         

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => User ??= new UserRepository(_context);
        public IUserDetailRepository UserDetailRepository => UserDetail ??= new UserDetailRepository(_context);
        public IVehicleTypeRepository VehicleTypeRepository => VehicleType ??= new VehicleTypeRepository(_context);

        public IVehicleFeatureRepository VehicleFeatureRepository => VehicleFeature ??= new VehicleFeatureRepository(_context);

        public IVehicleRepository VehicleRepository => Vehicle ??= new VehicleRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
