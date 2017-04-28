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
        public Exam exam { get; set; }
        public Question question { get; set; }
        public Answer selectedAnswer { get; set; }
    }
}
