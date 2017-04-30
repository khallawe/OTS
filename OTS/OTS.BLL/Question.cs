using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return dal.Delete(id);
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
            return dal.SelectOne(id);
        }

        public int Update(Model.Question question)
        {
            return dal.Update(question);
        }
    }
}
