using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    public class GenerateExamController : Controller
    {
        // GET: GenerateExam
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenerateExam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenerateExam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerateExam/Create
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

        // GET: GenerateExam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerateExam/Edit/5
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

        // GET: GenerateExam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerateExam/Delete/5
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
