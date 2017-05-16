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
    public class Student : IStudent
    {
        private static readonly IStudent dal = DataAccess.CreateInstance<IStudent>("Student");

        /// <summary>
        /// singleton
        /// </summary>
        public static Student Instance { get { Student Instance = new Student(); return Instance; } }

        public int Add(Model.Student user)
        {
           return dal.Add(user);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
                
        }

        public List<Model.Student> Search(string key)
        {
            return dal.Search(key);
        }

        public List<Model.Student> SelectAll()
        {
            return dal.SelectAll();
        }

        public Model.Student SelectOne(int id)
        {
            return dal.SelectOne(id);
        }
        public Model.Student SelectByAccessCode(string accessCode)
        {
            return dal.SelectByAccessCode(accessCode);
        }

        public int Update(Model.Student user)
        {
            return dal.Update(user);
        }
    }
}
