using Ridel.Application.Interfaces.Repositories;
using Ridel.Persistence.Contexts;

namespace Ridel.Persistence.Repositories.Vehicle
{
    public class VehicleRepository : GenericRepository<Domain.Entities.Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
