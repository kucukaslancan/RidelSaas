using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Domain.Entities;

namespace Ridel.Application.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUnitOfWork _uow;

        public UserDetailService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<int> UpsertAsync(UserDetail userDetail)
        {
            return _uow.UserDetailRepository.UpsertUserDetail(userDetail);
        }
    }
}
