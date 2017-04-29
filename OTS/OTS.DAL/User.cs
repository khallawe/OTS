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

        public int Add(Model.User user)
        {
            try
            {
                var existUser = db.UserSet.Count(x => x.userName == user.userName);
                if (existUser == 0)
                {
                    db.UserSet.Add(user);
                    db.SaveChanges();
                    return user.ID;
                }
                else
                {
                    return -1;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

       

        public Model.User CheckLogin(string userName, string pasword)
        {
            Model.User user = db.UserSet.FirstOrDefault(u => u.userName == userName && u.password == pasword);
            return user;
        }

        public int Delete(int id)
        {
            Model.User user =db.UserSet.FirstOrDefault(x => x.ID == id);
            db.UserSet.Remove(user);
            return db.SaveChanges();
        }

        public List<Model.User> Search(string key)
        {
            var users = from u in db.UserSet where u.name.ToLower().Contains(key.ToLower()) select u;
            return users.ToList();
        }

        public List<Model.User> SelectAll()
        {
           
            return db.UserSet.ToList();

        }

        public List<Model.User> SelectByGroup(Model.Group _group)
        {
            
            return db.UserSet.Where(x => x.Group_ID == _group.Group_ID).ToList();
        }

        

        public Model.User SelectOne(int id)
        {
            return  db.UserSet.FirstOrDefault(x => x.ID == id);
        }

        public int Update(Model.User user)
        {
            Model.User olduser = db.UserSet.FirstOrDefault(x => x.ID == user.ID);
            if (user.userName!= olduser.userName)
            {
                return -1;
            }
            olduser.name = user.name;
            olduser.userName = user.userName;
            olduser.password = user.password;
            olduser.ModifiedDate = user.ModifiedDate;
            olduser.ModifiedBy = user.ModifiedBy;
            olduser.group = user.group;
            return db.SaveChanges();

            
        }

        
    }
}
