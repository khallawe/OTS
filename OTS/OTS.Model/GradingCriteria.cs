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

        public int minVal { get; set; }
        public int maxVal { get; set; }
        public string grade { get; set; }
    }
}
