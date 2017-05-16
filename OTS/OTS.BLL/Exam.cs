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
    public class Exam : IExam
    {
        private static readonly IExam dal = DataAccess.CreateInstance<IExam>("Exam");

        /// <summary>
        /// singleton
        /// </summary>
        public static Exam Instance { get { Exam Instance = new Exam(); return Instance; } }

        public int Add(Model.Exam exam)
        {
            return dal.Add(exam);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool IsAccessKeyExist(string accessKey)
        {
            return dal.IsAccessKeyExist(accessKey);

        }

        public List<Model.Exam> Search(string key)
        {
            return dal.Search(key);
        }

        public List<Model.Exam> SelectAll()
        {
            return dal.SelectAll();
        }

        public Model.Exam SelectByAccessCode(string accessCode)
        {
            return dal.SelectByAccessCode(accessCode);
        }

        public List<Model.Exam> SelectByUserID(int userId)
        {
            return dal.SelectByUserID(userId);
        }

        public Model.Exam SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        public int Update(Model.Exam exam)
        {
            return dal.Update(exam);
        }
    }
}
