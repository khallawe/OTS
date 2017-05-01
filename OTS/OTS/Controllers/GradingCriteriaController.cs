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
    public class GradingCriteriaController : Controller
    {
        ErrorLog errorLog = new ErrorLog();
        // GET: GradingCriteria
        public ActionResult Index()
        {
            List<Model.GradingCriteria> gradingCriteria = BLL.GradingCriteria.Instance.SelectAll();

            return View(gradingCriteria);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy")] GradingCriteria gc)
        {
            try
            {
                if (BLL.GradingCriteria.Instance.CheckDuplicate(gc))
                {
                    ModelState.AddModelError("grading", "This criteria is already in use");
                }

                if (ModelState.IsValid)
                {
                    gc.CreatedDate = DateTime.Now;
                    gc.CreatedBy = ((Model.User)Session["User"]).ID;
                    int res = BLL.GradingCriteria.Instance.Add(gc);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                GradingCriteria gc = BLL.GradingCriteria.Instance.SelectOne(id);

                return View(gc);
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

                return View();
            }

        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedBy,ModifiedDate")]GradingCriteria gc)
        {
            try
            {
                if (BLL.GradingCriteria.Instance.CheckDuplicate(gc))
                {
                    ModelState.AddModelError("grading", "This criteria is already in use");
                }

                gc.ModifiedBy = ((Model.User)Session["User"]).ID;
                gc.ModifiedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    BLL.GradingCriteria.Instance.Update(gc);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            GradingCriteria gradingCriteria = BLL.GradingCriteria.Instance.SelectOne(id);
            return View(gradingCriteria);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GradingCriteria gradingCriteria = BLL.GradingCriteria.Instance.SelectOne(id);
            return View(gradingCriteria);
        }

        [HttpPost]
        public ActionResult Delete(GradingCriteria gradingCriteria)
        {
            try
            {
                BLL.GradingCriteria.Instance.Delete(gradingCriteria.ID);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

                return View();
            }
        }
    }
}