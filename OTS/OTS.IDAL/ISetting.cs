using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
   public interface ISetting
    {
        Setting SelectOne(int id);
        IDbSet<Setting> getDbSet();
        List<Setting>  SelectAll();
        int Update(Setting setting);
    }
}
