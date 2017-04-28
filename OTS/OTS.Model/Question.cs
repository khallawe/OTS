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
        public int ID { get; set; }
        public string question { get; set; }
        public SubInventory subInventory { get; set; }
        public int numberOfAnswers { get; set; }
        public List<Answer> answers { get; set; }
        public List<Exam> exams { get; set; }


    }
}
