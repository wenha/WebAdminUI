using APP.EntityFramework.Context;
using APP.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Web.Controllers
{
    public class BaseController : Controller
    {
        private LoginUser _loginUser;
        private APPContext _dbContext;

        public LoginUser LoginUser
        {
            get
            {
                if(_loginUser != null)
                {
                    return _loginUser;
                }
                return _loginUser;
            }
        }

        private APPContext DBContext
        {
            get
            {
                if(_dbContext != null)
                {
                    return _dbContext;
                }
                _dbContext = DependencyResolver.Current.GetService<APPContext>();
                return _dbContext;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                if (!DBContext.IsDisposed)
                {
                    using (DBContext)
                    {
                        if (DBContext.ChangeTracker.HasChanges())
                        {
                            DBContext.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            base.OnActionExecuted(filterContext); base.OnActionExecuted(filterContext);
        }
    }
}