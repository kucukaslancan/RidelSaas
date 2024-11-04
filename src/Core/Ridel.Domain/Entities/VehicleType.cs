using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class VehicleType : BaseEntity
    {
        public string Name { get; set; } // Economy, Business, SUV gibi araç türü adı
        public string Description { get; set; } // Tür hakkında açıklama


        // Bu türdeki araçlar
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
