using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {

                User user = BLL.User.Instance.CheckLogin(userName, password);
                if (user.ID > 0)
                {
                    Session["user"] = user;
                    FormsAuthentication.RedirectFromLoginPage(user.userName, false);
                }
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}