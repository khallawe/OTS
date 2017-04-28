using OTS.DALFactory;
using OTS.IDAL;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.BLL
{
   
    public class User: IUser
    {
        private static readonly IUser dal = DataAccess.CreateInstance<IUser>("User");

        /// <summary>
        /// singleton
        /// </summary>
        public static User Instance { get { User Instance = new User(); return Instance; } }

        public int Add(Model.User user)
        {
            return dal.Add(user);
            
        }

        

        public Model.User CheckLogin(string userName, string pasword)
        {
            Model.User user= dal.CheckLogin(userName, pasword);
            return user;
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public List<Model.User> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> SelectAll()
        {
           return dal.SelectAll();
        }

        public List<Model.User> SelectByGroup(Model.Group group)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> SelectByGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public Model.User SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        public int Update(Model.User user)
        {
            return dal.Update(user);
        }

        
    }
}
