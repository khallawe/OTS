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
        public string AnswerText { get; set; }
        public int QuestionID { get; set; }
        public virtual Question question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
