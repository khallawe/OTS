using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface ISubInventory
    {
        int Add(ISubInventory subInventory);
        int Update(ISubInventory subInventory);
        int Delete(int id);
        SubInventory SelectOne(int id);
        List<SubInventory> Search(string key);
        List<SubInventory> SelectAll();


        List<SubInventory> SelectBySubInventory(int inventoryId);
        List<SubInventory> SelectBySubExamAccessCode(string examAccessCode);
        List<SubInventory> SelectBySubExamID(int examId);


    }
}
