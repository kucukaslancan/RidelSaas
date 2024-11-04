using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Offer : BaseEntity
    {

        public Guid OrderId { get; set; } // Teklifin bağlı olduğu siparişin ID'si
        public Order Order { get; set; } // İlişkili Order

        public string AcceptedByUserId { get; set; } // Teklifi kabul eden kullanıcının ID'si
        public User AcceptedByUser { get; set; } // İlişkili kullanıcı (Driver veya Dispatcher)

        public DateTime AcceptedDate { get; set; } = DateTime.UtcNow; // Teklifin kabul edildiği tarih
    }
}
