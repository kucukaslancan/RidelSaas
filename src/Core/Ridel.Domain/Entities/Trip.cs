using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public Guid OrderId { get; set; } // Yolculuğun bağlı olduğu siparişin ID'si
        public Order Order { get; set; } // İlişkili sipariş

        public string DriverId { get; set; } // Yolculuğu gerçekleştiren sürücünün (Driver) ID'si
        public User Driver { get; set; } // İlişkili sürücü

        public string DispatcherId { get; set; } // Siparişi oluşturan dispatcher'ın ID'si
        public User Dispatcher { get; set; } // İlişkili dispatcher (varsa)

        public DateTime TripDate { get; set; } // Yolculuk tarihi
        public TimeSpan Duration { get; set; } // Yolculuk süresi
        public decimal Cost { get; set; } // Yolculuk ücreti

        public TripStatus Status { get; set; } // Yolculuğun durumu (Tamamlandı, İptal Edildi vb.)

        public enum TripStatus
        {
            Completed,
            Cancelled,
            Pending
        }
    }
}
