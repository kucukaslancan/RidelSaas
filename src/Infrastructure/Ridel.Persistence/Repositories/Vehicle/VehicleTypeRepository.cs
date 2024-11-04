using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;
using Ridel.Persistence.Contexts;

namespace Ridel.Persistence.Repositories.Vehicle
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
