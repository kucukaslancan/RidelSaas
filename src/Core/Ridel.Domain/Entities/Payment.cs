using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string UserId { get; set; } // Ödemeyi yapan kullanıcının ID'si
        public User User { get; set; } // İlişkili kullanıcı (Driver veya Dispatcher)

        public PaymentType Type { get; set; } // Ödeme türü (Sipariş Komisyonu, Abonelik Ücreti vb.)
        public decimal Amount { get; set; } // Ödeme miktarı
        public string Currency { get; set; } // Para birimi
        public DateTime PaymentDate { get; set; } // Ödeme tarihi
        public PaymentStatus Status { get; set; } // Ödeme durumu (Tamamlandı, Beklemede vb.)
        public string PaymentOrderNumber { get; set; }

        public enum PaymentType
        {
            OrderCommission,
            SubscriptionFee,
            PenaltyFee
        }

        public enum PaymentStatus
        {
            Completed,
            Pending,
            Failed
        }
    }
}
