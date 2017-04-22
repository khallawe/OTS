using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Answer:Base
    {
        public string answer { get; set; }
        public Question question { get; set; }
        public bool isCorrect { get; set; }
    }
}
