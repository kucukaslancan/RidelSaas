using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;
using Ridel.Persistence.Contexts;

namespace Ridel.Persistence.Repositories.Vehicle
{
    public class VehicleFeatureRepository : GenericRepository<VehicleFeature>, IVehicleFeatureRepository
    {
        public VehicleFeatureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
