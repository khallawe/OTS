using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface ISubInventory
    {
        int Add(SubInventory subInventory);
        int Update(SubInventory subInventory);
        int Delete(int id);
        SubInventory SelectOne(int id);
        List<SubInventory> Search(string key);
        List<SubInventory> SelectAll();
        IDbSet<SubInventory> getDbSet();
        List<SubInventory> SelectBySubInventory(int inventoryId);
        List<SubInventory> SelectBySubExamAccessCode(string examAccessCode);
        List<SubInventory> SelectBySubExamID(int examId);


    }
}
