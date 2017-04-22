using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IInventory
    {
        int Add(IInventory inventory);
        int Update(IInventory inventory);
        int Delete(int inventoryID);
        Inventory SelectOne(int id);
        List<SubInventory> Search(string key);
        List<Inventory> SelectAll();
      
    }
}
