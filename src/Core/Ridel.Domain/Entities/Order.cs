using Ridel.Domain.Common;
using Ridel.Domain.ValueObjects.Order;

namespace Ridel.Domain.Entities
{
    public class Order : BaseEntity
    {
        public OrderDetails Details { get; set; } // Sipariş detayları Value Object olarak
        public string CreatedByUserId { get; set; } // Siparişi oluşturan kullanıcının ID'si (Driver veya Dispatcher)
        public User CreatedByUser { get; set; } // İlişkili kullanıcı (Driver veya Dispatcher)

        public Offer Offer { get; set; } // Siparişe verilen teklif (yalnızca bir tane olabilir)

        public OrderStatus Status { get; set; } // Siparişin durumu (Yeni, Atandı, Tamamlandı vs.)

        public Trip Trip { get; set; } // Yolculuk


        public enum OrderStatus
        {
            New,
            Assigned,
            Completed,
            Cancelled
        }
    }



}
