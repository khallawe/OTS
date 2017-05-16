using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OTS.Model
{
    public class ExamLog:Base
    {
        [Key]
        public int ID { get; set; }
        public int examId { get; set; }
        public virtual Exam exam { get; set; }
        public int questionId { get; set; }
        public virtual Question question { get; set; }
        public int selectedAnswerId { get; set; }
        public virtual Answer selectedAnswer { get; set; }
    }
}
