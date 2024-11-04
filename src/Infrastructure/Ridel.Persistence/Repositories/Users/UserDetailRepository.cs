using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;
using Ridel.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Persistence.Repositories.Users
{
    public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> UpsertUserDetail(UserDetail userDetail)
        {
            var existingDetail = _context.UserDetails.FirstOrDefault(ud => ud.UserId == userDetail.UserId);

            if (existingDetail == null)
            {
                // Eğer yoksa ekle
                await _context.UserDetails.AddAsync(userDetail);
            }
            else
            {
                // Eğer varsa güncelle
                existingDetail.CompanyName = userDetail.CompanyName;
                existingDetail.EIN = userDetail.EIN;
                existingDetail.CompanyAddress = userDetail.CompanyAddress;
                existingDetail.ContactPerson = userDetail.ContactPerson;
                existingDetail.CompanyPhoneNumber = userDetail.CompanyPhoneNumber;
                existingDetail.CompanyEmail = userDetail.CompanyEmail;
                existingDetail.BirthDate = userDetail.BirthDate;
                existingDetail.WorkRegion = userDetail.WorkRegion;


                _context.UserDetails.Update(existingDetail);
            }

            return await _context.SaveChangesAsync();
        }
    }
}
