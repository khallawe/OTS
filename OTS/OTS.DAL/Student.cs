using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    class Student : IStudent
    {
        OTSContext db = new OTSContext();

        public int Add(Model.Student user)
        {
            
            try
            {
                var existStudent = db.StudentSet.Count(x => x.studentID == user.studentID);
                if (existStudent == 0)
                {
                    db.StudentSet.Add(user);
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

        public int Delete(int id)
        {
            Model.Student student = db.StudentSet.FirstOrDefault(x => x.ID == id);
            db.StudentSet.Remove(student);
            return db.SaveChanges();
        }

        public List<Model.Student> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Student> SelectAll()
        {
            return db.StudentSet.ToList();
        }

        public Model.Student SelectOne(int id)
        {
            return db.StudentSet.FirstOrDefault(x => x.ID == id);
        }

        public int Update(Model.Student user)
        {
            Model.Student olduser = db.StudentSet.FirstOrDefault(x => x.ID == user.ID);
            if (user.studentID != olduser.studentID)
            {
                return -1;
            }
            olduser.studentName = user.studentName;
            olduser.studentEmail = user.studentEmail;
            olduser.ModifiedDate = user.ModifiedDate;
            olduser.ModifiedBy = user.ModifiedBy;
            return db.SaveChanges();
        }
    }
}
