using Microsoft.EntityFrameworkCore;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;
using Ridel.Persistence.Contexts;

namespace Ridel.Persistence.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserWithDetailsByIdAsync(string userId)
        {
            return await _context.Users
                .Include(u => u.UserDetail)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<bool> HasUserDetails(string userId)
        {
            var userDetail = await _context.UserDetails
                .FirstOrDefaultAsync(ud => ud.UserId == userId);
            return userDetail != null;
        }
    }
}
