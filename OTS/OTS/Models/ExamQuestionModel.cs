using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OTS.Model;

namespace OTS.Models
{
    public class ExamQuestionModel
    {
        public Question question { get; set; }
        public int selectedAnswer { get; set; }
        public bool done { get; set; }
    }
}