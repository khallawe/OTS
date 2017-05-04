using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.Model;
using OTS.Authentication;
using OTS.code;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class SettingController : Controller
    {
        



        public ActionResult Index()
        {
            try
            {
                List<Setting> setting = BLL.Setting.Instance.SelectAll();

                return View(setting);
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View();

            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {

                Setting setting = BLL.Setting .Instance.SelectOne(id);

                return View(setting);
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return RedirectToAction("Index");

            }

        }

        //POST: Setting/Edit/
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ModifiedBy,ModifiedDate")]Setting setting)

        {
            try
            {
                setting.ModifiedBy = ((Model.User)Session["User"]).ID;
                setting.ModifiedDate = DateTime.Now;
                //setting.CreatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    BLL.Setting.Instance.Update(setting);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View(setting);

            }
        }







    }
}