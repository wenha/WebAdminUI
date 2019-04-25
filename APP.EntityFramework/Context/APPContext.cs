using APP.Core.Roles;
using APP.Core.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Context
{
    public class APPContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>, IContextDependency
    {
        public bool IsDisposed { get; private set; } = false;

        public APPContext() : base("Default")
        {

        }

        static APPContext()
        {
            Database.SetInitializer<APPContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
        }

        public static APPContext Create()
        {
            return new APPContext();
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
    }
}
