using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;

namespace OTS.BLL
{
   public class Question : IQuestion
    {
        private static readonly IQuestion dal = DataAccess.CreateInstance<IQuestion>("Question");

        /// <summary>
        /// singleton
        /// </summary>
        public static Question Instance { get { Question Instance = new Question(); return Instance; } }

        public int Add(Model.Question question)
        {
            return dal.Add(question);
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
            return dal.SelectAll();
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
