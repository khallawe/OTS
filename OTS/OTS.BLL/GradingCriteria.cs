using OTS.DALFactory;
using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;

namespace OTS.BLL
{
    public class GradingCriteria : IGradingCriteria
    {
        private static readonly IGradingCriteria dal = DataAccess.CreateInstance<IGradingCriteria>("GradingCriteria");

        /// <summary>
        /// singleton
        /// </summary>
        public static GradingCriteria Instance { get { GradingCriteria Instance = new GradingCriteria(); return Instance; } }

        public int Add(Model.GradingCriteria gradingCriteria)
        {
            return dal.Add(gradingCriteria);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public List<Model.GradingCriteria> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.GradingCriteria> SelectAll()
        {
            return dal.SelectAll();
        }

        public Model.GradingCriteria SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        public int Update(Model.GradingCriteria gradingCriteria)
        {
            return dal.Update(gradingCriteria);
        }

        public bool CheckDuplicate(Model.GradingCriteria gradingCriteria)
        {
            List<Model.GradingCriteria> list = dal.SelectAll();
            foreach (Model.GradingCriteria gc in list)
            {
                if (gc.maxVal == gradingCriteria.maxVal && gc.minVal == gradingCriteria.minVal)
                    return true;
            }
            return false;
        }
    }
}
