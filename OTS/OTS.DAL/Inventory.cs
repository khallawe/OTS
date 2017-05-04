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

        public int Add(Model.Inventory inventory)
        {
            using (var db = new OTSContext())
            {
                db.InventorySet.Add(inventory);
                return db.SaveChanges();
            }



        }
        //Delete is making Update  to  in Active 
        public int Delete(int inventoryID)
        {
            using (var db = new OTSContext())
            {
                Model.Inventory inventoryToDelete = db.InventorySet.Single(x => x.InventoryID == inventoryID);
                inventoryToDelete.IsActive = false;
                //db.InventorySet.Remove(inventoryToDelete);
                return db.SaveChanges();
            }


        }

        public List<Inventory> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Inventory> SelectAll()
        {
            List<Model.Inventory> data;
            using (var db = new OTSContext())
            {
                data = db.InventorySet.Where(x => x.IsActive == true).OrderByDescending(p => p.InventoryID).Take(200).ToList();
            }
            return data;

        }

        public Model.Inventory SelectOne(int id)
        {
            Model.Inventory inventory;
            using (var db = new OTSContext())
            {
                inventory = db.InventorySet.Single(x => x.InventoryID == id);
                return inventory;
            }




        }

        public int Update(Model.Inventory inventory)
        {
            using (var db = new OTSContext())
            {

                Model.Inventory inventoryToUpdate = db.InventorySet.SingleOrDefault(x => x.InventoryID == inventory.InventoryID);
                inventoryToUpdate.ModifiedBy = inventory.ModifiedBy;
                inventoryToUpdate.ModifiedDate = inventory.ModifiedDate;
                inventoryToUpdate.name = inventory.name;
                inventoryToUpdate.description = inventory.description;
                return db.SaveChanges();
            }

        }

        List<Model.SubInventory> IInventory.Search(string key)
        {
            throw new NotImplementedException();
        }

        public IDbSet<Model.Inventory> getDbSet()
        {

            OTSContext db = new OTSContext();

              return db.InventorySet;

        }


    }
}
