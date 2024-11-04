using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class VehicleFeature : BaseEntity
    {
        public string FeatureName { get; set; } // Örneğin, "Deri Koltuk", "Navigasyon"
        public string Description { get; set; } // Özellik hakkında açıklama

        // Bu özelliklerin kullanıldığı araçlar
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
