using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OTS.Model
{
    public class Group: Base
    {
        [Key]
        public int Group_ID { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public string groupName { get; set; }
        public List<Role> roles { get; set; }
        public virtual List<User> users { get; set; }
    }
}
