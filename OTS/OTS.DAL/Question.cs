using System;
using System.Collections.Generic;
using System.Linq;
using OTS.IDAL;
using System.Data.Entity;

namespace OTS.DAL
{
    class Question : IQuestion
    {
        public int Add(Model.Question question)
        {
            using (var db = new OTSContext())
            {
                db.QuestionSet.Add(question);
                return db.SaveChanges();
            }
            
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
            List<Model.Question> data;

            using (var db = new OTSContext())
            {
                return data=db.QuestionSet.Include(x => x.SubInventory.inventory).ToList();
            }
            
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
            throw new NotImplementedException();
        }

        public int Update(Model.Question question)
        {
            throw new NotImplementedException();
        }
    }
}
