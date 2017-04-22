using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class GradingCriteria : Base
    {

        public int minVal { get; set; }
        public int maxVal { get; set; }
        public string grade { get; set; }
    }
}
