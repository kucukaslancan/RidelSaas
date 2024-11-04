using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithDetailsByIdAsync(string userId);
        Task<bool> HasUserDetails(string userId);
    }
}
