using OTS.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.Model;

namespace OTS.Controllers
{
    [AuthenticateStudentSession]
    public class StudentHomeController : Controller
    {
        // GET: StudentHome
        public ActionResult Index()
        {
            Student student = (Student)Session["Student"];
            
            return View(student);
        }

        // GET: StudentHome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentHome/Create
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

        // GET: StudentHome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentHome/Edit/5
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

        // GET: StudentHome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentHome/Delete/5
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
