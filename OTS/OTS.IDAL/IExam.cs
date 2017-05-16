using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IExam
    {
        int Add(Exam exam);
        int Update(Exam exam);
        int Delete(int id);
        Exam SelectOne(int id);
        List<Exam> SelectAll();
        List<Exam> Search(string key);
        bool IsAccessKeyExist(string accessKey);

        List<Exam> SelectByUserID(int userId);
        Exam SelectByAccessCode(string accessCode);
    }
}
