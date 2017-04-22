using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IRole
    {
        int Add(IRole role);
        int Update(IRole role);
        int Delete(int id);
        Role SelectOne(int id);
        List<Role> SelectAll();
        List<Role> Search(string key);
        List<Role> Search(int groupId);
    }
}
