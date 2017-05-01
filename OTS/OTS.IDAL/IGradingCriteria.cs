using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IGradingCriteria
    {
        int Add(GradingCriteria gradingCriteria);
        int Update(GradingCriteria gradingCriteria);
        int Delete(int id);
        GradingCriteria SelectOne(int id);
        List<GradingCriteria> SelectAll();
        List<GradingCriteria> Search(string key);
    }
}
