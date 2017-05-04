using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OTS.Model
{
    public class GradingCriteria : Base
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public int minVal { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public int maxVal { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public string grade { get; set; }
    }
}
