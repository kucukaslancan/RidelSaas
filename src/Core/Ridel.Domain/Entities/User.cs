using Microsoft.AspNetCore.Identity;
using Ridel.Domain.Enums;

namespace Ridel.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRoles Role { get; set; } // Kullanıcı rolü (Admin, Driver, Dispatcher)

        public string? ProfilePhotoUrl { get; set; } // Profil fotoğrafı URL'si (AWS S3 vb. bir yerde saklanacak)

        // Navigation Properties
        public ICollection<Order> OrdersCreated { get; set; } // Kullanıcının oluşturduğu siparişler
        public ICollection<Offer> OffersAccepted { get; set; } // Kullanıcının kabul ettiği teklifler

        // Driver için özel özellikler
        public ICollection<Vehicle> Vehicles { get; set; } // Sürücüye ait araçlar

        // Kullanıcı detayları
        public UserDetail UserDetail { get; set; }
        public ICollection<Subscription>  Subscriptions { get; set; }
    }
}
