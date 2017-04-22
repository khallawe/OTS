using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IUser
    {
       #region basic Method

        int Add(IUser user);
        int Update(IUser user);
        int Delete(int id);
        User SelectOne(int id);
        List<User> Search(string key);
        List<User> SelectAll();
        #endregion

        List<User> SelectByGroup(Group group);



    }
}
