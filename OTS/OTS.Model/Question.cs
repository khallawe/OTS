using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Question: Base
    {
        public string question { get; set; }
        public SubInventory subInventory { get; set; }
        public int numberOfAnswers { get; set; }
        public List<Answer> answers { get; set; }
        public List<Exam> exams { get; set; }


    }
}
