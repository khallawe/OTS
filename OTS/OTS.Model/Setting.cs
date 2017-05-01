using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Setting: Base
    {
        [Key]
        public int SettingID { get; set; }
        public int ExamTime { get; set; }
        public int MaxQuestionsInSubInventories { get; set; }
        public int MinSubInventories { get; set; }
        public int MaxSubInventories { get; set; }  
        public int RandomLength { get; set; }
        public int QuestionGrades { get; set; }
        public int ValidTimeAccess { get; set; }

    }
}
