using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<User> users = BLL.User.Instance.SelectAll();
            return View(users);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

    }
}