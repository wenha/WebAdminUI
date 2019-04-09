using APP.Core.Roles;
using APP.Core.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    public interface IIdentityManager
    {
        Task<IdentityResult> CreateUserAsync(User user, string password);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> CreateRoleAsync(Role role);

        Task<IdentityResult> UpdateRoleAsync(Role role);

        Task<IdentityResult> DeleteRoleAsync(Role role);

        string HashPassword(string password);
    }
}
