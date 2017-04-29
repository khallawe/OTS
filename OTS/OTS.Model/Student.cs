using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    class Student: Base
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public int studentID { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public string studentName { get; set; }
        [Required(ErrorMessage = "this field Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string studentEmail { get; set; }
        
    }
}
