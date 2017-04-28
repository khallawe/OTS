using OTS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Model;
using System.Data.Entity;

namespace OTS.DAL
{
    public class Inventory : IInventory
    {
		OTSContext db = new OTSContext();


        public int Add(Model.Inventory inventory)
		{
          //  var existInventory = db.InventorySet.Count(x => x.name == inventory.name);
          //  if (existInventory == 0)
           // {
                db.InventorySet.Add(inventory);
                return db.SaveChanges();
          //  }
            //{
            //    return -1;
            //}
		
		}

		public int Delete(int inventoryID)
		{
            Model.Inventory inventoryToDelete = db.InventorySet.SingleOrDefault(x =>x.InventoryID == inventoryID);
            db.InventorySet.Remove(inventoryToDelete);
            return  db.SaveChanges();
		}

		public List<Inventory> Search(string key)
		{
			throw new NotImplementedException();
		}

		public List<Model.Inventory> SelectAll()
		{
			return db.InventorySet.ToList();
		}

		public Model.Inventory SelectOne(int id)
		{
            return db.InventorySet.Single(x => x.InventoryID == id);
		}

		public int Update(Model.Inventory inventory)
		{
            Model.Inventory inventoryToUpdate = db.InventorySet.SingleOrDefault(x => x.InventoryID == inventory.InventoryID);
            //inventoryToUpdate.InventoryID = inventory.InventoryID;
            inventoryToUpdate.ModifiedBy = inventory.ModifiedBy;
            inventoryToUpdate.ModifiedDate = inventory.ModifiedDate;
            inventoryToUpdate.name = inventory.name;
            inventoryToUpdate.description = inventory.description;
            return db.SaveChanges();
		}

        List<Model.SubInventory> IInventory.Search(string key)
        {
            throw new NotImplementedException();
        }

        public IDbSet<Model.Inventory> getDbSet()
        {
            return db.InventorySet;
        }


    }
}
