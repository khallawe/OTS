
using OTS.Model;
using System.Collections.Generic;


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
