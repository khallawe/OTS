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
            return dal.SelectByExam(examID);
        }

        public List<Model.Question> SelectBySubInventory(int subinventoryId)
        {
            return dal.SelectBySubInventory(subinventoryId);
        }

        public Model.Question SelectOne(int id)
        {
            try
            {
                return dal.SelectOne(id);
            }
            catch
            {
                return null;
            }
        }

        public List<Model.Question> SelectRandomBySubInventory(int subinventoryId)
        {
            return dal.SelectRandomBySubInventory(subinventoryId);
        }

        public int Update(Model.Question question)
        {
            return dal.Update(question);
        }
    }
}
