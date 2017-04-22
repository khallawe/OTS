using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Exam: Base
    {
        public string accessId { get; set; }
        public User  user { get; set; }
        public List<SubInventory> chosenSubInventories { get; set; }
        public List<Question> questions { get; set; }
        public bool isTaken { get; set; }
        public string grade { get; set; }
        public DateTime dateTaken { get; set; }
    }
}
