using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class User : Base
    {

        [Required(ErrorMessage = "this field Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "this field Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string userName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        public Group group { get; set; }

    }
}
