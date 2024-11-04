using Ridel.Domain.Entities;

namespace Ridel.Application.Interfaces.Repositories
{
    public interface IUserDetailRepository : IRepository<UserDetail>
    {
        Task<int> UpsertUserDetail(UserDetail userDetail);
    }
}
