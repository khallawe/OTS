using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.DAL;
using OTS.Model;
using OTS.Authentication;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class QuestionsController : Controller
    {
        ErrorLog errorLog = new ErrorLog();
       
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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                BLL.ErrorLog.Instance.Add(errorLog);
                return RedirectToAction("Create");
            }
        }


        [HttpGet]
        public ActionResult Add()
        {
            //TempData["InventoryID"] = new SelectList(BLL.Inventory.Instance.getDbSet(), "InventoryID", "name");
            return View();
        }

        [HttpPost]
        public JsonResult Add(Model.Question question)
        {
            question.CreatedBy = ((Model.User)Session["User"]).ID;
            question.CreatedDate= DateTime.Now;
            foreach(Model.Answer item in question.Answers)
            {
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = ((Model.User)Session["User"]).ID;
            }
           
            DAL.OTSContext db = new DAL.OTSContext();

            if (ModelState.IsValid)
            {
                db.QuestionSet.Add(question);
                db.SaveChanges();
            }
               

            


            return Json(question);
        }

        public ActionResult FillInventoryDDL()
        {
            List<Model.Inventory> inventory = BLL.Inventory.Instance.SelectAll();
            return Json(
                inventory.Select(x => new {
                    InventoryID = x.InventoryID,
                    name = x.name
                }), JsonRequestBehavior.AllowGet);
        }


    }
}