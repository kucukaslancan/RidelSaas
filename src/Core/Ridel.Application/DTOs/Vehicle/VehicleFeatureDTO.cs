namespace Ridel.Application.DTOs.Vehicle
{
    public class VehicleFeatureDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Economy, Business, SUV gibi araç türü adı
        public string Description { get; set; } // Tür hakkında açıklama
        public bool IsDeleted { get; set; }
    }
}
