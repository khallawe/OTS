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
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            List<Group> groups = BLL.Group.Instance.SelectAll();

            return View(groups);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ModifiedDate,ModifiedBy")]Group group)
        {
            
            group.CreatedDate = DateTime.Now;
            group.CreatedBy = ((User)Session["user"]).ID;
            group.groupName.ToLower();

            if (ModelState.IsValid)
            {
                try
                {
                    int res = BLL.Group.Instance.Add(group);
                    if (res==-1)
                    {
                        ModelState.AddModelError(group.groupName,"this Group name already exist");
                        return View(group);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return View();

                }
            }

            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Group group = BLL.Group.Instance.SelectOne(id);
            return View(group);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedDate,CreatedBy")] Group group)
        {
            group.ModifiedBy = ((User)Session["user"]).ID;
            group.ModifiedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                int res = BLL.Group.Instance.Update(group);
                if (res==0)
                {
                    return View();
                }

            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Group group = BLL.Group.Instance.SelectOne(id);
            return View(group);
        }
        [HttpPost]
        public ActionResult Delete(Group group)
        {
            int res = BLL.Group.Instance.Delete(group.Group_ID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Group group = BLL.Group.Instance.SelectOne(id);
            return View(group);
        }
        public ActionResult FillUserGroup()
        {
            var groups = BLL.Group.Instance.SelectAll();
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

    }

}