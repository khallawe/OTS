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
        public string QuestionText { get; set; }
        public virtual SubInventory SubInventory { get; set; }
        public int SubInventoryID { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Exam> Exams { get; set; }


    }
}
