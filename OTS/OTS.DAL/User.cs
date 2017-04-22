using OTS.IDAL;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.DAL
{
    public class User : IUser
    {
        OTSContext db = new OTSContext();
        public int Add(IUser user)
        {
            throw new NotImplementedException();
        }

        public Model.User CheckLogin(string userName, string pasword)
        {
            Model.User user = db.UserSet.FirstOrDefault(u => u.userName == userName && u.password == pasword);
            return user;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> SelectAll()
        {
           
            return db.UserSet.ToList();

        }

        public List<Model.User> SelectByGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public Model.User SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
