using Ridel.Domain.Enums;

namespace Ridel.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoles Role { get; set; } // Driver veya Dispatcher
    }
}
