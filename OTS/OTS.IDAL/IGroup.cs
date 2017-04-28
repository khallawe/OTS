using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IGroup
    {
        int Add(Group group);
        int Update(Group group);
        int Delete(int id);
        Group SelectOne(int id);
        List<Group> SelectAll();
        List<Group> Search(string key);
        IDbSet<Model.Group> getGroupsDbSet();
    }
}
