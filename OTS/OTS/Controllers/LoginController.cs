using OTS.Helper;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
                try
                {
                    password = CCrypt.Encrypt(password);
                    User user = BLL.User.Instance.CheckLogin(userName, password);
                    if (user.ID > 0)
                    {
                        Session["user"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "User Name Or Password is Not Correct ";
                        return View();
                    }
                    
                }
                catch (Exception)
                {
                    ViewBag.Error = "User Name Or Password is Not Correct ";
                    return View();
                }
                
            }

            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            try
            {
                Session["User"] = null;
                return RedirectToAction("Login");
            }
            catch (Exception)
            {

                return RedirectToAction("Login");
            }
           
        }
        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult StudentLogin(string accessCode)
        {
            if (!string.IsNullOrEmpty(accessCode) )
            {
                try
                {

                    Student student = BLL.Student.Instance.SelectByAccessCode(accessCode);
                    if (student.ID > 0)
                    {
                        Session["Student"] = student;
                        Session["accessCode"] = accessCode;
                        return RedirectToAction("Index", "StudentHome");
                    }
                    else
                    {
                        ViewBag.Error = "Access code is not correct";
                        return View();
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Access code is not correct ";
                    return View();
                }

            }

            return View();
        }
    }
}