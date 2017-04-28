using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class ExamQuestion:Base
    {
        public Exam exam { get; set; }
        public List<Question> questions { get; set; }
    }
}
