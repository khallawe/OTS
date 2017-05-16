using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using System.Data.Entity;

namespace OTS.DAL
{
    class Question : IQuestion
    {
        public int Add(Model.Question question)
        {
            OTSContext db = new OTSContext();
            db.QuestionSet.Add(question);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Question> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Question> SelectAll()
        {
            OTSContext db = new OTSContext();
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
            OTSContext db = new OTSContext();
            return db.QuestionSet.Single(x => x.QuestionID == id);
        }

        public List<Model.Question> SelectRandomBySubInventory(int subinventoryId)
        {
            OTSContext db = new OTSContext();
            List<Model.Question> allQuestion = db.QuestionSet.Include("Answers").Where(x => x.SubInventoryID == subinventoryId).ToList();
            List < Model.Question > list = allQuestion.OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            return list;
        }

        public int Update(Model.Question question)
        {
            OTSContext db = new OTSContext();
            Model.Question questionToUpdate = db.QuestionSet.SingleOrDefault(x => x.QuestionID == question.QuestionID);
            questionToUpdate.ModifiedBy = question.ModifiedBy;
            questionToUpdate.ModifiedDate = question.ModifiedDate;
            questionToUpdate.SubInventoryID = question.SubInventoryID;
            questionToUpdate.QuestionText = question.QuestionText;
            questionToUpdate.IsActive = question.IsActive;
            return db.SaveChanges();
        }
    }
}
