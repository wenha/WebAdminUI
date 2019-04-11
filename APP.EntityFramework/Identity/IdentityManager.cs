using APP.Common;
using APP.Core;
using APP.Core.Roles;
using APP.Core.Users;
using APP.EntityFramework.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Identity
{
    public class IdentityManager : IIdentityManager, IDependency, IDisposable
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly IdentityRoleManager _identityRoleManager;

        public IdentityManager(APPContext context)
        {
            _identityUserManager = IdentityUserManager.Create(context);
            _identityRoleManager = IdentityRoleManager.Create(context);
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {

            return await _identityUserManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _identityUserManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _identityUserManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> CreateRoleAsync(Role role)
        {
            return await _identityRoleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateRoleAsync(Role role)
        {
            return await _identityRoleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(Role role)
        {
            return await _identityRoleManager.DeleteAsync(role);
        }

        public string HashPassword(string password)
        {
            return _identityUserManager.PasswordHasher.HashPassword(password);
        }

        public void Dispose()
        {
            _identityUserManager?.Dispose();
            _identityRoleManager?.Dispose();
        }
    }
}
