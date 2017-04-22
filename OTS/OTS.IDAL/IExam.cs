using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IExam
    {
        int Add(IExam exam);
        int Update(IExam exam);
        int Delete(int id);
        Exam SelectOne(int id);
        List<Exam> SelectAll();
        List<Exam> Search(string key);


        List<Exam> SelectByUserID(int userId);
        Exam SelectByAccessCode(string accessCode);
    }
}
