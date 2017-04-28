using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class Group: Base
    {
        public string groupName { get; set; }
        public List<Role> roles { get; set; }
    }
}
