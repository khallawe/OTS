using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OTS.Model
{
    public class Answer:Base
    {
        [Key]
        public int AnswerID { get; set; }
        public string answer { get; set; }
        public int QuestionID { get; set; }
        public Question question { get; set; }
        public bool isCorrect { get; set; }
    }
}
