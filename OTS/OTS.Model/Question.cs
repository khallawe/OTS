using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OTS.Model
{
    public class Question: Base
    {
        [Key]
        public int QuestionID { get; set; }
        public string question { get; set; }
        public SubInventory subInventory { get; set; }
        public int SubInventoryID { get; set; }
        public int numberOfAnswers { get; set; }
        public List<Answer> answers { get; set; }
        public List<Exam> exams { get; set; }


    }
}
