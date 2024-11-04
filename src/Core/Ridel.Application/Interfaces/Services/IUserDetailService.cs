using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces.Services
{
    public interface IUserDetailService
    {
        Task<int> UpsertAsync(UserDetail userDetail);
    }
}
