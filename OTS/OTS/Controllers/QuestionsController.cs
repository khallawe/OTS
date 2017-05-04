using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.DAL;
using OTS.Model;
using OTS.Authentication;
using OTS.code;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class QuestionsController : Controller
    {

       
        // GET: Questions
        public ActionResult Index()
        {
            try
            {

                List<Question> questions = BLL.Question.Instance.SelectAll();

                return View(questions);
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return RedirectToAction("Create");
            }
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Model.Question question)
        {
            try
            {
                question.CreatedBy = ((Model.User)Session["User"]).ID;
                question.CreatedDate = DateTime.Now;
                foreach (Model.Answer item in question.Answers)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = ((Model.User)Session["User"]).ID;
                }

             //   DAL.OTSContext db = new DAL.OTSContext();

                if (ModelState.IsValid)
                {
                   BLL.Question.Instance.Add(question);
                }

                return Json(question);
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return Json(question);
            }
        }

        //public ActionResult FillInventoryDDL()
        //{
        //    List<Model.Inventory> inventory = BLL.Inventory.Instance.SelectAll();
        //    return Json(
        //        inventory.Select(x => new {
        //            InventoryID = x.InventoryID,
        //            name = x.name
        //        }), JsonRequestBehavior.AllowGet);
        //}


    }
}