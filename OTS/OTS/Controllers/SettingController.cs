using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.Model;
using OTS.Authentication;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class SettingController : Controller
    {
        ErrorLog errorLog = new ErrorLog();



        public ActionResult Index()
        {
            try
            {
                List<Setting> setting = BLL.Setting.Instance.SelectAll();

                return View(setting);
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                BLL.ErrorLog.Instance.Add(errorLog);
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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                BLL.ErrorLog.Instance.Add(errorLog);
                return View();

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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                BLL.ErrorLog.Instance.Add(errorLog);
                return View();

            }
        }







    }
}