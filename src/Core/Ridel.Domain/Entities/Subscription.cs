using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public string UserId { get; set; } // Abonelik sahibi kullanıcı ID'si
        public User User { get; set; } // İlişkili kullanıcı

        public DateTime StartDate { get; set; } // Aboneliğin başlangıç tarihi
        public DateTime EndDate { get; set; } // Aboneliğin bitiş tarihi
        public bool IsActive { get; set; } // Abonelik aktif mi?

        public decimal AmountPaid { get; set; } // Kullanıcının ödediği toplam ücret
        public decimal SubscriptionFee { get; set; } // Abonelik ücreti (örneğin, driver için 25$)

        public SubscriptionType Type { get; set; } // Abonelik türü (Driver veya Dispatcher)

        public Guid SubscriptionPackageId { get; set; } // Abonelik paketinin ID'si
        public SubscriptionPackage SubscriptionPackage { get; set; } // İlişkili paket

        public enum SubscriptionType
        {
            Driver,
            Dispatcher
        }
    }
}
