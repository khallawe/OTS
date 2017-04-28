﻿using OTS.Model;
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
                    User user = BLL.User.Instance.CheckLogin(userName, password);
                    if (user.ID > 0)
                    {
                        Session["user"] = user;
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return View();
                }
                
            }

            return View();
        }

    }
}