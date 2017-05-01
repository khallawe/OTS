using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IStudent
    {
        #region basic Method

        int Add(Student user);
        int Update(Student user);
        int Delete(int id);
        Student SelectOne(int id);
        List<Student> Search(string key);
        List<Student> SelectAll();
        #endregion
        
    }
}
