using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class SubInventory: Base
    {
        public Inventory inventory { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Exam> exams { get; set; }
        public List<Question> questions { get; set; }

    }
}
