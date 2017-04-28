using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
  public  interface IInventory
    {
        int Add(Inventory inventory);
        int Update(Inventory inventory);
        int Delete(int inventoryID);
        Inventory SelectOne(int id);
        List<SubInventory> Search(string key);
        List<Inventory> SelectAll();
        IDbSet<Inventory> getDbSet();

    }
}
