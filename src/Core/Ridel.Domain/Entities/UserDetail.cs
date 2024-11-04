using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class UserDetail : BaseEntity
    {


        // User ile birebir ilişki
        public string UserId { get; set; }
        public User User { get; set; }

        // Dispatcher için özel bilgiler
        public string? CompanyName { get; set; } // Firma Adı
        public string? EIN { get; set; } // Vergi No
        public string? CompanyAddress { get; set; } // Şirket Adresi
        public string? ContactPerson { get; set; } // Firma Yetkilisi
        public string? CompanyPhoneNumber { get; set; } // Firma Telefonu
        public string? CompanyEmail { get; set; } // Firma E-Postası

        // Driver için özel bilgiler
        public DateTime? BirthDate { get; set; } // Doğum Tarihi
        public string? WorkRegion { get; set; } // Çalışma Bölgesi (Eyalet ve Şehir)
    }
}
