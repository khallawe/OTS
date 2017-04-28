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
        public int ID { get; set; }
        public string groupName { get; set; }
        public List<Role> roles { get; set; }
    }
}
