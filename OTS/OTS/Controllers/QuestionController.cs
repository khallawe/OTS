
using OTS.Authentication;
using OTS.IDAL;
using OTS.Model;
using OTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class QuestionController : Controller    
    {

        [NonAction]
        private void PrepareInventoryModel(QuestionModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var inventories = BLL.Inventory.Instance.SelectAll();
            foreach (var inventory in inventories)
            {
                model.AvailableInventories.Add(new SelectListItem()
                {
                    Text = inventory.name,
                    Value = inventory.InventoryID.ToString()
                });
            }
            
            var selectedInventoryID = inventories[0].InventoryID;
            if (model.InventoryId != 0)
                selectedInventoryID = model.InventoryId;
            var subInventories = BLL.SubInventory.Instance.SelectByInventory(selectedInventoryID);
            foreach (var subInventory in subInventories)
            {
                model.AvailableSubInventories.Add(new SelectListItem()
                {
                    Text = subInventory.name,
                    Value = subInventory.SubInventoryID.ToString()
                });
            }
        }

        public ActionResult FillSubInventories(int inventoryId)
        {
            var subInventories = BLL.SubInventory.Instance.SelectByInventory(inventoryId);
            return Json(
                subInventories.Select(x => new {
                    SubInventoryID = x.SubInventoryID,
                    name = x.name
                }), JsonRequestBehavior.AllowGet);
        }

        // GET: Question
        public ActionResult Index()
        {
            
            List<QuestionModel> listQuestionModel = new List<QuestionModel>();
            var questions =  BLL.Question.Instance.SelectAll();

            foreach (var q in questions)
            {
                QuestionModel questionModel = new QuestionModel();
                questionModel.Id = q.QuestionID;
                questionModel.Question = q.question;
                questionModel.NumberOfAnswers = q.numberOfAnswers;
                questionModel.SubInventoryId = q.SubInventoryID;
                SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(q.SubInventoryID);
                questionModel.SubInventoryName = subInventory.name;
                var inventory = BLL.Inventory.Instance.SelectOne(subInventory.InventoryID);
                questionModel.InventoryId = inventory.InventoryID;
                questionModel.InventoryName = inventory.name;
                
                //PrepareInventoryModel(questionModel);
                listQuestionModel.Add(questionModel);
            }
            return View(listQuestionModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new QuestionModel();

            PrepareInventoryModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(QuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var question = new Question();
            question.question = model.Question;
            question.numberOfAnswers = model.NumberOfAnswers;
            question.CreatedDate = DateTime.Now;
            question.CreatedBy = ((Model.User)Session["user"]).ID;
            question.SubInventoryID = model.SubInventoryId;
            int id = BLL.Question.Instance.Add(question);
            //return View(model);
            return RedirectToAction("Edit", new { id = id });
        }

        public ActionResult Edit(int id)
        {
            QuestionModel questionModel = new QuestionModel();
            Question question = BLL.Question.Instance.SelectOne(id);
            questionModel.Id = id;
            questionModel.Question = question.question;
            questionModel.NumberOfAnswers = question.numberOfAnswers;
            questionModel.SubInventoryId = question.SubInventoryID;
            SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(question.SubInventoryID);
            questionModel.InventoryId = subInventory.InventoryID;
            PrepareInventoryModel(questionModel);

            List<Answer> answers = BLL.Answer.Instance.SelectByQuestionID(id);
            for(int i = answers.Count; i < 10; i++)
            {
                Answer emptyAnswer = new Answer();
                emptyAnswer.answer = "";
                emptyAnswer.AnswerID = 0;
                emptyAnswer.QuestionID = id;
                emptyAnswer.isCorrect = false;
                answers.Add(emptyAnswer);
            }
            questionModel.AvailableAnswers = answers;

            return View(questionModel);

        }

        [HttpPost]
        public ActionResult Edit(QuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Question question = BLL.Question.Instance.SelectOne(model.Id);
            question.question = model.Question;
            question.numberOfAnswers = model.NumberOfAnswers;
            question.ModifiedDate = DateTime.Now;
            question.ModifiedBy = ((Model.User)Session["user"]).ID;
            question.SubInventoryID = model.SubInventoryId;

            BLL.Question.Instance.Update(question);
            return RedirectToAction("Edit", new { id = model.Id });
        }

        public ActionResult Delete(int id)
        {
            BLL.Question.Instance.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult SaveAnswers(AnswerModel[] models)
        {
            Answer answer;
            foreach(AnswerModel model in models)
            {
                if (model.AnswerID == 0 && (model.answer != null && !model.answer.Equals("")))    //add
                {
                    answer = new Answer();
                    answer.answer = model.answer;
                    answer.isCorrect = model.isCorrect;
                    answer.QuestionID = model.QuestionID;
                    answer.CreatedDate = DateTime.Now;
                    answer.CreatedBy = ((Model.User)Session["user"]).ID;
                    BLL.Answer.Instance.Add(answer);
                    continue;
                }
                if (model.AnswerID != 0 && (model.answer != null && !model.answer.Equals("")))    //update
                {
                    answer = BLL.Answer.Instance.SelectOne(model.AnswerID);
                    answer.answer = model.answer;
                    answer.isCorrect = model.isCorrect;
                    answer.QuestionID = model.QuestionID;
                    answer.ModifiedDate = DateTime.Now;
                    answer.ModifiedBy = ((Model.User)Session["user"]).ID;
                    BLL.Answer.Instance.Update(answer);
                    continue;
                }
                if (model.AnswerID != 0 && (model.answer == null || model.answer.Equals(""))) //delete
                {
                    BLL.Answer.Instance.Delete(model.AnswerID);
                    continue;
                }
            }
            return RedirectToAction("Edit", new { id = models[0].QuestionID });
        }
    }
}