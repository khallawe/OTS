using OTS.Authentication;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            ViewBag.userName = user.name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}