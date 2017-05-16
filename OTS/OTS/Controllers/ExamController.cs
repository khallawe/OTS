using OTS.Authentication;
using OTS.Model;
using OTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OTS.Controllers
{
    [AuthenticateStudentSession]
    public class ExamController : Controller
    {

        public ActionResult QuestionsList()
        {
            List<ExamQuestionModel> list = new List<ExamQuestionModel>();
            List<Question> qList = BLL.Question.Instance.SelectRandomBySubInventory(2);
            foreach (var item in qList)
            {
                ExamQuestionModel q = new ExamQuestionModel();
                q.question = item;
                list.Add(q);
            }
            
            return View(list);
        }
        // GET: Exam
        public ActionResult Index()
        {
            Student student = (Student)Session["Student"];
            Session["selectedSubInventory"] = "";
            return View(student);
        }
        [HttpGet]
        public ActionResult test()
        {
            Dictionary<int, ExamQuestionModel> qs = new Dictionary<int, ExamQuestionModel>();
            //List<ExamQuestionModel> qs = new List<ExamQuestionModel>();
            List<Question> qList = BLL.Question.Instance.SelectRandomBySubInventory(2);
            foreach (var item in qList)
            {
                ExamQuestionModel current2 = new ExamQuestionModel { question = item, done = false };
                qs.Add(current2.question.QuestionID,current2);
            }
            ExamQuestionModel current = (ExamQuestionModel)from x in qs where x.Value.done == false select x;
            Session["Exam55"] = qs;
            return View(current);
        }
        [HttpPost]
        public ActionResult test(ExamQuestionModel exam,string selectedAnswer)
        {
            exam.done = true;
            Dictionary<int, ExamQuestionModel> qs = (Dictionary<int, ExamQuestionModel>)Session["Exam55"];
            qs.Add(exam.question.QuestionID,exam);
            ExamQuestionModel current = (ExamQuestionModel)from x in qs where x.Value.done == false select x;
            return View(current);
        }
        [HttpGet]
        public ActionResult StartExam1()
        {
            var accessKey = Session["accessCode"];
            var SubInventory = Session["selectedSubInventory"];
            Model.Exam exam = BLL.Exam.Instance.SelectByAccessCode(accessKey.ToString());
            exam.student = (Student)Session["Student"];
            List<Model.Question> questions = new List<Model.Question>();
            string[] SubInventorylist = SubInventory.ToString().Split(',');
            foreach (var item in SubInventorylist)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int currentId = int.Parse(item);
                    List<Question> qList = BLL.Question.Instance.SelectRandomBySubInventory(currentId);
                    SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(currentId);
                    questions.AddRange(qList);
                    exam.chosenSubInventories.Add(subInventory);
                }
            }
            exam.questions = questions;
            Dictionary<int, ExamLog> questionsDic = new Dictionary<int, ExamLog>();
            foreach (var item in questions)
            {
                //questionsDic.Add(item.QuestionID, ExamLog);
            }
            return View(exam);
        }
        [HttpGet]
        public ActionResult StartExam()
        {
            var accessKey = Session["accessCode"];
            var SubInventory = Session["selectedSubInventory"];
            if (string.IsNullOrEmpty(SubInventory.ToString()))
            {
                SubInventory = "2,7,8";

            }
            Model.Exam exam = BLL.Exam.Instance.SelectByAccessCode(accessKey.ToString());
            exam.student = (Student)Session["Student"];
            List<Model.Question> questions = new List<Model.Question>();
            string[] SubInventorylist = SubInventory.ToString().Split(',');
            foreach (var item in SubInventorylist)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int currentId = int.Parse(item);
                    List<Question> qList = BLL.Question.Instance.SelectRandomBySubInventory(currentId);
                    SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(currentId);
                    questions.AddRange(qList);
                    //exam.chosenSubInventories.Add(subInventory);
                }
            }
            exam.questions = questions;
            Session["exam"] = exam;
            return View(exam);
        }
        public void UpdateAnswer(string answer)
        {
            Exam exam = (Exam)Session["exam"];
            string[] QW = answer.Split('-');
            int qID = int.Parse(QW[0]);
            int aID = int.Parse(QW[1]);
            Question currentQuestion = exam.questions.FirstOrDefault(x => x.QuestionID == qID);
            Answer currentAnswer = currentQuestion.Answers.FirstOrDefault(x => x.AnswerID == aID);
            ExamLog log = new ExamLog();
            log.exam = exam;
            log.selectedAnswerId = 1;
        }
        [HttpPost]
        public ActionResult StartExam(Exam exam)
        {

            //return RedirectToAction("create", "Archives",1);
            return RedirectToAction("create", new RouteValueDictionary(
            new { controller = "Archives", action = "create", Id = 1 }));
        }
        // GET: Exam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exam/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exam/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
