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

        [Required(ErrorMessage = "This field Required")]
        public int ExamTime { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int MaxQuestionsInSubInventories { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int MinSubInventories { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int MaxSubInventories { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int RandomLength { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int QuestionGrades { get; set; }

        [Required(ErrorMessage = "This field Required")]
        
        public int ValidTimeAccess { get; set; }

    }
}
