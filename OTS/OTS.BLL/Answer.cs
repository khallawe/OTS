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
    public class Answer : IAnswer
    {
        private static readonly IAnswer dal = DataAccess.CreateInstance<IAnswer>("Answer");

        /// <summary>
        /// singleton
        /// </summary>
        public static Answer Instance { get { Answer Instance = new Answer(); return Instance; } }
        public int Add(Model.Answer answer)
        {
            return dal.Add(answer);
        }

        public int Delete(int answerID)
        {
            return dal.Delete(answerID);
        }

        public List<Model.Answer> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Answer> SelectAll()
        {
            return dal.SelectAll();
        }

        public List<Model.Answer> SelectByQuestionID(int questionID)
        {
            return dal.SelectByQuestionID(questionID);
        }

        public Model.Answer SelectCorrectAnswer(int questionID)
        {
            throw new NotImplementedException();
        }

        public Model.Answer SelectOne(int id)
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

        public int Update(Model.Answer answer)
        {
            return dal.Update(answer);
        }
    }
}
