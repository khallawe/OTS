using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IGroup
    {
        int Add(IGroup group);
        int Update(IGroup group);
        int Delete(int id);
        Group SelectOne(int id);
        List<Group> SelectAll();
        List<Group> Search(string key);
    }
}
