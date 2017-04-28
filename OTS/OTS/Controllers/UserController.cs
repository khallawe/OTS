using OTS.Authentication;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<Model.User> users = BLL.User.Instance.SelectAll();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            Model.User user = BLL.User.Instance.SelectOne(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            TempData["Groups"] = new SelectList(BLL.Group.Instance.getGroupsDbSet(), "ID", "groupName");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")]User user)
        {
            try
            {
                // TODO: Add insert logic here
                user.CreatedBy = ((User)Session["User"]).ID;
                user.CreatedDate = DateTime.Now;
                Group g = BLL.Group.Instance.SelectOne(1);
                user.group = g;
                if (ModelState.IsValid)
                {
                    int res =BLL.User.Instance.Add(user);
                    if (res>0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(user.userName, "this user already exist");
                        return View(user);
                    }
                        
                }
                return View(user);


            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            Model.User user = BLL.User.Instance.SelectOne(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")]User user)
        {
            try
            {
                user.ModifiedBy = ((Model.User)Session["User"]).ID;
                user.ModifiedDate = DateTime.Now;
                

                if (ModelState.IsValid)
                {
                   int res = BLL.User.Instance.Update(user);
                    
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("userName", "this user already exist");
                        return View(user);
                    }
                    

                }
            }
            catch
            {
                return View();
            }
            return View(user);
        }

        // GET: User/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            Model.User user = BLL.User.Instance.SelectOne(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                BLL.User.Instance.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
