﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Base
    {
 
        /// <summary>
        /// Get CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Get CreatedBy
        /// </summary>
        public int CreatedBy { get; set; }
        

        /// <summary>
        /// Get ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Get ModifiedBy
        /// </summary>
        public int? ModifiedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
