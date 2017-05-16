using OTS.Authentication;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students =BLL.Student.Instance.SelectAll();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = BLL.Student.Instance.SelectOne(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")]Student student)
        {
            try
            {
                student.CreatedBy = ((Model.User)Session["User"]).ID;
                student.CreatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    int res = BLL.Student.Instance.Add(student);
                    if (res>0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("studentID", "this user already exist");
                        return View(student);
                    }
                }
                return View(student);

            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = BLL.Student.Instance.SelectOne(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ModifiedDate,ModifiedBy")]Student student)
        {
            try
            {
                student.ModifiedBy = ((Model.User)Session["User"]).ID;
                student.ModifiedDate = DateTime.Now;
                if(ModelState.IsValid)
                {
                    int res = BLL.Student.Instance.Update(student);
                    if (res>0)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("studentID", "this user already exist");
                        return View(student);
                    }
                }

                return View(student);
            }
            catch
            {
                return View(student);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            Student student = BLL.Student.Instance.SelectOne(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                BLL.Student.Instance.Delete(student.ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }
        [HttpGet]
        [ActionName("Assessment")]
        public ActionResult Assessment_Get(int id)
        {
            Student student = BLL.Student.Instance.SelectOne(id);
            return View(student);
        }
        [HttpPost]
        [ActionName("Assessment")]
        public ActionResult Assessment_Post(int id)
        {
            Student student = BLL.Student.Instance.SelectOne(id);
            string AccessCode;
            bool codeNotExist = true;
            do
            {
                AccessCode = Helper.RandomCode.RandomString(25);
                codeNotExist = BLL.Exam.Instance.IsAccessKeyExist(AccessCode);
                

            } while (codeNotExist);
            
            Exam exam = new Exam();
            exam.accessId = AccessCode;
            exam.studentId = student.ID;
            exam.CreatedBy = ((Model.User)Session["User"]).ID;
            exam.CreatedDate = DateTime.Now;
            int res = BLL.Exam.Instance.Add(exam);
            if (res>0)
            {
                
                string host = Request.Url.Host.ToString();
                if (!string.IsNullOrEmpty(Request.Url.Port.ToString()))
                {
                    host += ":" + Request.Url.Port.ToString();
                }
                string fullUrl ="http://"+ host + "/login/StudentLogin";
                StringBuilder emailTemp = new StringBuilder();

                emailTemp.Append("Dear: " + student.studentName+ "<br>");
                emailTemp.Append("to take the online assessment you need to go to this link "+ fullUrl+ "<br>");
                emailTemp.Append("your access code is: " + AccessCode + "<br>");
                Helper.SMTP.SendEmail(student.studentEmail, "MUM online Assessment", emailTemp);
                // localhost
                // send email to student 
                // redirect to students page
            }
            return View(student);
        }

    }
}
