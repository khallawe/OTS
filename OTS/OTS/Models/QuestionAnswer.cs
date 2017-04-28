using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OTS.Model;

namespace OTS.Models
{
    public class QuestionAnswer
    {
        public Question question { get; set; }
        public List<Answer> answers { get; set; }

    }
}