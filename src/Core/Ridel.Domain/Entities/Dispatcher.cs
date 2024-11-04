using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Dispatcher : BaseEntity
    {

        public string UserId { get; set; }
        public User User { get; set; } // User ile ilişkisi
        public decimal SubscriptionFee { get; set; } = 15m; // Aylık abonelik ücreti

        // Firma Bilgileri
        public string CompanyName { get; set; }
        public string EINNumber { get; set; } // Vergi numarası
        public string CompanyAddress { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
    }
}
