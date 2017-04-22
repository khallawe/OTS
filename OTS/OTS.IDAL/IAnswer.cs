using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IAnswer
    {
        int Add(IAnswer question);
        int Update(IAnswer question);
        int Delete(int questionID);
        Answer SelectOne(int id);
        List<Answer> Search(string key);

        List<Answer> SelectAll();

        List<Answer> SelectByQuestionID(int questionID);
        Answer SelectCorrectAnswer(int questionID);
    }
}
