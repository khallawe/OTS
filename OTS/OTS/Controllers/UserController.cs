using OTS.Authentication;
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

    [AuthenticateAdminSession]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<User> users = BLL.User.Instance.SelectAll();
            return View(users);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}