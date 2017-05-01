using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.DAL
{
    public class GradingCriteria : IGradingCriteria
    {
        OTSContext db = new OTSContext();

        public int Add(Model.GradingCriteria gradingCriteria)
        {
            db.GradingCriteriaSet.Add(gradingCriteria);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Model.GradingCriteria gradingCriteria = db.GradingCriteriaSet.SingleOrDefault(x => x.ID == id);
            db.GradingCriteriaSet.Remove(gradingCriteria);
            return db.SaveChanges();
        }

        public List<Model.GradingCriteria> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.GradingCriteria> SelectAll()
        {
            return db.GradingCriteriaSet.ToList();
        }

        public Model.GradingCriteria SelectOne(int id)
        {
            return db.GradingCriteriaSet.Single(x => x.ID == id);
        }

        public int Update(Model.GradingCriteria gradingCriteria)
        {
            Model.GradingCriteria oldOne = db.GradingCriteriaSet.SingleOrDefault(x => x.ID == gradingCriteria.ID);
            oldOne.ModifiedBy = gradingCriteria.ModifiedBy;
            oldOne.ModifiedDate = gradingCriteria.ModifiedDate;
            oldOne.maxVal = gradingCriteria.maxVal;
            oldOne.minVal = gradingCriteria.minVal;
            oldOne.grade = gradingCriteria.grade;
            return db.SaveChanges();
        }
    }
}
