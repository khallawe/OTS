﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Setting: Base
    {
        [Key]
        public int ID { get; set; }
        public int examTime { get; set; }
        public int maxQuestionsInSubInventories { get; set; }
        public int minSubInventories { get; set; }
        public int maxSubInventories { get; set; }  
        public int randomLength { get; set; }
        public int questionGrades { get; set; }
        public int validTimeAccess { get; set; }

    }
}
