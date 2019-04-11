using APP.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserApplication UserApplication;

        public HomeController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var data = UserApplication.GetUsers(u => u.RealName == "张三");

            return Json(data);
        }
    }
}