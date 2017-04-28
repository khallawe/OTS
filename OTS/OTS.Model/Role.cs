using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OTS.Model
{
    public class Role : Base
    {
        [Key]
        public int ID { get; set; }
        public string roleName { get; set; }
        public string roleDesc { get; set; }
        public List<Group> groups { get; set; }
    }
}
