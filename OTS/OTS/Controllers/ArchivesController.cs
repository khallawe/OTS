using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.Models;
using OTS.DAL;
using OTS.Authentication;
using System.Data.Entity;

namespace OTS.Controllers
{
    
    public class ArchivesController : Controller
    {
        // GET: Archives
        // Every Student then we will have another table for all exam log then report then how to print 
        //
        public ActionResult Index()
        {
            OTSContext db = new OTSContext();
            List<Model.Student> students= db.StudentSet.ToList();
            return View(students);
        }

        public ActionResult Details(int id)
        {
            OTSContext db = new OTSContext();
            List<Model.Exam> exams = db.ExamSet.Where(x => x.studentId == id & x.isTaken==true).ToList(); ;


            return View(exams);
        }



        [HttpGet]
        public ActionResult Create(int id)
        {
            ArchivesViewModel archivesViewModel = new ArchivesViewModel();
            OTSContext db  = new OTSContext();
            archivesViewModel.Exam = db.ExamSet.Include("Student").Include("chosenSubInventories").SingleOrDefault(x => x.ID == id);
            
          //  archivesViewModel.GradingCriteria = db.GradingCriteriaSet.SingleOrDefault(x => x.ID == 1);
            archivesViewModel.Setting=db.SettingSet.SingleOrDefault(x => x.SettingID == 1);






            return View(archivesViewModel);
        }
    }
}