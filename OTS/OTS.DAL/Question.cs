using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    public class Question : IQuestion
    {
        OTSContext db = new OTSContext();

        public int Add(Model.Question question)
        {
            db.QuestionSet.Add(question);
            db.SaveChanges();
            return question.QuestionID;
        }

        public int Delete(int id)
        {
            Model.Question question = db.QuestionSet.SingleOrDefault(x => x.QuestionID == id);
            db.QuestionSet.Remove(question);
            return db.SaveChanges();
        }

        public List<Model.Question> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Question> SelectAll()
        {
            return db.QuestionSet.ToList();
        }

        public List<Model.Question> SelectByExam(int examID)
        {
            throw new NotImplementedException();
        }

        public List<Model.Question> SelectBySubInventory(int subinventoryId)
        {
            throw new NotImplementedException();
        }

        public Model.Question SelectOne(int id)
        {
            return db.QuestionSet.Single(x => x.QuestionID == id);
        }

        public int Update(Model.Question question)
        {
            Model.Question oldQuestion = db.QuestionSet.SingleOrDefault(x => x.QuestionID == question.QuestionID);
            oldQuestion.ModifiedBy = question.ModifiedBy;
            oldQuestion.ModifiedDate = question.ModifiedDate;
            oldQuestion.question = question.question;
            oldQuestion.numberOfAnswers = question.numberOfAnswers;
            return db.SaveChanges();
        }
    }
}
