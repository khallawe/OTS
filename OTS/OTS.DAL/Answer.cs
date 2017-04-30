using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    public class Answer : IAnswer
    {
        OTSContext db = new OTSContext();
        public int Add(Model.Answer answer)
        {
            db.AnswerSet.Add(answer);
            db.SaveChanges();
            return answer.AnswerID;
        }

        public int Delete(int answerID)
        {
            Model.Answer answer = db.AnswerSet.SingleOrDefault(x => x.AnswerID == answerID);
            db.AnswerSet.Remove(answer);
            return db.SaveChanges();
        }

        public List<Model.Answer> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Answer> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<Model.Answer> SelectByQuestionID(int questionID)
        {
            return db.AnswerSet.Where(x => x.QuestionID == questionID).ToList();
        }

        public Model.Answer SelectCorrectAnswer(int questionID)
        {
            throw new NotImplementedException();
        }

        public Model.Answer SelectOne(int id)
        {
            return db.AnswerSet.Single(x => x.AnswerID == id);
        }

        public int Update(Model.Answer answer)
        {
            Model.Answer oldAnswer = db.AnswerSet.SingleOrDefault(x => x.AnswerID == answer.AnswerID);
            oldAnswer.ModifiedBy = answer.ModifiedBy;
            oldAnswer.ModifiedDate = answer.ModifiedDate;
            oldAnswer.answer = answer.answer;
            oldAnswer.isCorrect = answer.isCorrect;
            return db.SaveChanges();
        }
    }
}
