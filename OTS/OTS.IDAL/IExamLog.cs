using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IExamLog
    {
        int Add(IExamLog examLog);
        int Update(IExamLog examLog);
        int Delete(int id);
        ExamLog SelectOne(int id);
        List<ExamLog> SelectAll();
        List<ExamLog> Search(string key);
        ExamLog SelectByExamId(int examId);
        ExamLog SelectByExamAccessCode(string examAccessCode);
    }
}
