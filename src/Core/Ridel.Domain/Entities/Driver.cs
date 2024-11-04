using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Driver : BaseEntity
    {
     
        public string UserId { get; set; }
        public User User { get; set; } // İlişkili kullanıcı (User entity'si)

        public decimal SubscriptionFee { get; set; } = 25m; // Aylık abonelik ücreti
        public decimal OrderCommission { get; set; } = 0.50m; // Sipariş başına komisyon ücreti

        // Araçlar
        public ICollection<Vehicle> Vehicles { get; set; } // Sürücüye ait araçlar

        // Sürücü profili
        public string ProfilePhotoUrl { get; set; } // Profil fotoğrafı URL'si (AWS S3 vb. bir yerde saklanacak)
        public string WorkingRegion { get; set; } // Sürücünün çalıştığı bölge (eyalet ve şehir)

 
    }
}
