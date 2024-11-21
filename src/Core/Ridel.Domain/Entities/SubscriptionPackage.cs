using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class SubscriptionPackage : BaseEntity
    {
        public string Name { get; set; } // Paket adı (örneğin, Driver, Dispatcher, Free Trial)
        public decimal Price { get; set; } // Abonelik ücreti (örneğin, 25$)
        public int DurationInDays { get; set; } // Abonelik süresi (gün olarak) (örneğin, 30 gün)

        // Ek paket detayları
        public bool IsFreeTrial { get; set; } // Ücretsiz deneme paketi mi?
        public string Description { get; set; } // Paket açıklaması (opsiyonel)
 
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
