using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OTS.Model;

namespace OTS.Models
{
    public class ArchivesViewModel
    {

        public ExamLog ExamLog { get; set; }
        public Setting Setting { get; set; }
        public GradingCriteria GradingCriteria { get; set; }
        public Exam Exam { get; set; }

    }
}