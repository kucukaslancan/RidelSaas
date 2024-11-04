using Ridel.Domain.Entities;

namespace Ridel.Application.DTOs.User
{
    public class UserInfoDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Role { get; set; } // Kullanıcı rolü (Admin, Driver, Dispatcher)
        public string? ProfilePhotoUrl { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }

        // Kullanıcı detayları
        public UserDetailDTO UserDetail { get; set; }
    }
}
