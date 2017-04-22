using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class ExamLog:Base
    {
        public Exam exam { get; set; }
        public Question question { get; set; }
        public Answer selectedAnswer { get; set; }
    }
}
