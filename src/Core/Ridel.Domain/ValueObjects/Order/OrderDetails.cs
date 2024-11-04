using Ridel.Domain.Common;

namespace Ridel.Domain.ValueObjects.Order
{
    public class OrderDetails : BaseEntity
    {
        public string PickupLocation { get; private set; } // Alış noktası
        public string DropOffLocation { get; private set; } // Bırakma noktası
        public DateTime PickupTime { get; private set; } // Alış zamanı
        public int NumberOfPassengers { get; private set; } // Yolcu sayısı
        public string CustomerName { get; private set; } // Müşteri adı
        public string VehicleType { get; private set; } // Araç tipi
        public decimal Price { get; private set; } // Fiyat
        public string Currency { get; private set; } // Para birimi

        private OrderDetails() { } // EF Core için gerekli

        public OrderDetails(
            string pickupLocation,
            string dropOffLocation,
            DateTime pickupTime,
            int numberOfPassengers,
            string customerName,
            string vehicleType,
            decimal price,
            string currency)
        {
            if (string.IsNullOrWhiteSpace(pickupLocation) || string.IsNullOrWhiteSpace(dropOffLocation))
                throw new ArgumentException("Pickup ve DropOff noktaları boş olamaz.");

            PickupLocation = pickupLocation;
            DropOffLocation = dropOffLocation;
            PickupTime = pickupTime;
            NumberOfPassengers = numberOfPassengers;
            CustomerName = customerName;
            VehicleType = vehicleType;
            Price = price;
            Currency = currency;
        }
    }
}
