namespace Ridel.Domain.ValueObjects.Vehicle
{
    public class VehiclePlate
    {
        public string PlateNumber { get; private set; }

        private VehiclePlate() { } // EF Core için gerekli

        public VehiclePlate(string plateNumber)
        {
            if (string.IsNullOrWhiteSpace(plateNumber))
                throw new ArgumentException("Plaka numarası boş olamaz.");

            // Özel format kontrolü (örneğin, ABD plaka formatı)
            if (!IsValidFormat(plateNumber))
                throw new ArgumentException("Geçersiz plaka formatı.");

            PlateNumber = plateNumber;
        }

        private bool IsValidFormat(string plateNumber)
        {
            // Özel format kontrolü yapılabilir
            return true; // Şimdilik örnek bir validasyon
        }
    }
}
