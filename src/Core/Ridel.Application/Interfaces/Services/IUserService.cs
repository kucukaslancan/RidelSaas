using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(User user);
        Task UpdateUserDetailsAsync(UserDetail userDetails);
        Task<bool> HasUserDetailsAsync();
        Task DeleteUserAsync(string userId);
    }
}
