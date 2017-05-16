using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.DAL;
using OTS.Model;
using OTS.Authentication;
using OTS.Helper.ExportImport;

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
        public ActionResult ExportXlsx()
        {
            try
            {
                ExportManager exportManager = new ExportManager();
                var bytes = exportManager.ExportQuestionsAnswersToXlsx(BLL.Answer.Instance.SelectAll().OrderBy(x => x.QuestionID));

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "questionsanswers.xlsx");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ImportFromXlsx()
        {
            try
            {
                ImportManager importManager = new ImportManager();
                var file = Request.Files["importexcelfile"];
                if (file != null && file.ContentLength > 0)
                {
                    importManager.ImportQuestionsAnswersFromXlsx(file.InputStream, ((Model.User)Session["User"]).ID);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                return RedirectToAction("Index");
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