using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    public class SetSessionController : Controller
    {
        // GET: SetSession
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SetVariable(string key, string value)
        {
            Session[key] = value;

            return this.Json(new { success = true });
        }
    }
}