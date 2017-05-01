using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;

namespace OTS.DAL
{
    class Question : IQuestion
    {
        public int Add(IQuestion question)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Update(IQuestion question)
        {
            throw new NotImplementedException();
        }
    }
}
