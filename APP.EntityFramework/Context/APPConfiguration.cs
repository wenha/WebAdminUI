using APP.Core.Roles;
using APP.Core.Users;
using APP.EntityFramework.Identity;
using APP.Model.Enum;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Context
{
    public class APPConfiguration : DbMigrationsConfiguration<APPContext>
    {
        public APPConfiguration()
        {
            //AutomaticMigrationsEnabled = true;
            // 是否开启自动同步实体-数据库字段
            AutomaticMigrationsEnabled = false;
            ContextKey = "APP.EntityFramework.Context.APPContext";
        }

        protected override void Seed(APPContext context)
        {
            InitializeIdentity(context);
        }
        public static void InitializeIdentity(APPContext db)
        {
            var userManager = IdentityUserManager.Create(db);
            var roleManager = IdentityRoleManager.Create(db);
            const string name = "admin";
            const string password = "123qwe";

            const string roleName = "admin_system";
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new Role { Name = "admin_system", Description = "系统管理员" };
                roleManager.Create(role);
            }
            var user = userManager.FindByName(name);
            if (user != null)
                return;
            user = new User { UserName = name, Email = name, RealName = "系统管理员", RoleId = role.Id, UserType = EUserType.SystemAdmin, CreateTime = DateTime.Now };
            userManager.Create(user, password);
            // 关闭用户登录锁定
            userManager.SetLockoutEnabled(user.Id, false);
        }
    }
}
