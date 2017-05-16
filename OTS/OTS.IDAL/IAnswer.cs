using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IAnswer
    {
        int Add(Answer question);
        int Update(Answer question);
        int Delete(int questionID);
        Answer SelectOne(int id);
        List<Answer> Search(string key);

        List<Answer> SelectAll();

        List<Answer> SelectByQuestionID(int questionID);
        Answer SelectCorrectAnswer(int questionID);
    }
}
