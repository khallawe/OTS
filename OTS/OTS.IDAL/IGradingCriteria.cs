using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IGradingCriteria
    {
        int Add(IGradingCriteria gradingCriteria);
        int Update(IGradingCriteria gradingCriteria);
        int Delete(int id);
        GradingCriteria SelectOne(int id);
        List<GradingCriteria> SelectAll();
        List<GradingCriteria> Search(string key);
    }
}
