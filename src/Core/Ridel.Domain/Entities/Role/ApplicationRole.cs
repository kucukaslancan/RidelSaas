using Microsoft.AspNetCore.Identity;

namespace Ridel.Domain.Entities.Role
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
