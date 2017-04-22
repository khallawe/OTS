using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Role : Base
    {
        public string roleName { get; set; }
        public string roleDesc { get; set; }
        public List<Group> groups { get; set; }
    }
}
