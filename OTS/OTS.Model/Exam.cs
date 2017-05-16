using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OTS.Model
{
    public class Exam: Base
    {
        [Key]
        public int ID { get; set; }
        public string accessId { get; set; }
        public int studentId { get; set; }
        public virtual Student  student { get; set; }
        public List<SubInventory> chosenSubInventories { get; set; }
        public List<Question> questions { get; set; }
        public bool isTaken { get; set; }
        public string grade { get; set; }
        public DateTime? dateTaken { get; set; }
    }
}
