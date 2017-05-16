using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    public class Exam : IExam
    {
        OTSContext db = new OTSContext();

        public int Add(Model.Exam exam)
        {
            try
            {
                var existUser = db.ExamSet.Count(x => x.accessId == exam.accessId);
                if (existUser == 0)
                {
                    db.ExamSet.Add(exam);
                    db.SaveChanges();
                    return exam.ID;
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
            throw new NotImplementedException();
        }

        public bool IsAccessKeyExist(string accessKey)
        {
            Model.Exam exam = db.ExamSet.FirstOrDefault(x => x.accessId == accessKey);
            
            if (exam!=null)
            {
                return true;
            }
            return false;
        }

        public List<Model.Exam> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Exam> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Model.Exam SelectByAccessCode(string accessCode)
        {
            return db.ExamSet.FirstOrDefault(x => x.accessId == accessCode);
        }

        public List<Model.Exam> SelectByUserID(int userId)
        {
            throw new NotImplementedException();
        }

        public Model.Exam SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Model.Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
