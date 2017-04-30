using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using System.Data.Entity;

namespace OTS.DAL
{
    class SubInventory : ISubInventory
    {
        OTSContext db = new OTSContext();

        public int Add(Model.SubInventory subInventory)
        {
           
            db.SubInventorySet.Add(subInventory);
            return db.SaveChanges();

        }

       

        public int Delete(int subInventoryID)
        {
            Model.SubInventory SubInventoryToDelete = db.SubInventorySet.SingleOrDefault(x => x.SubInventoryID == subInventoryID);
            db.SubInventorySet.Remove(SubInventoryToDelete);
            return db.SaveChanges();
        }

        public List<SubInventory> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.SubInventory> SelectAll()
        {
            return db.SubInventorySet.ToList();
        }

        public Model.SubInventory SelectOne(int id)
        {
            return db.SubInventorySet.Single(x => x.SubInventoryID == id);
        }

        

        public int Update(Model.SubInventory subInventory)
        {
            Model.SubInventory SubInventoryToUpdate = db.SubInventorySet.SingleOrDefault(x => x.SubInventoryID == subInventory.SubInventoryID);
            SubInventoryToUpdate.SubInventoryID = subInventory.SubInventoryID;
            SubInventoryToUpdate.InventoryID = subInventory.InventoryID;
            SubInventoryToUpdate.ModifiedBy = subInventory.ModifiedBy;
            SubInventoryToUpdate.ModifiedDate = subInventory.ModifiedDate;
            SubInventoryToUpdate.name = subInventory.name;
            SubInventoryToUpdate.description = subInventory.description;
            return db.SaveChanges();
        }



        public List<Model.SubInventory> SelectBySubExamAccessCode(string examAccessCode)
        {
            throw new NotImplementedException();
        }

        public List<Model.SubInventory> SelectBySubExamID(int examId)
        {
            throw new NotImplementedException();
        }

        public List<Model.SubInventory> SelectBySubInventory(int inventoryId)
        {
            throw new NotImplementedException();
        }

        List<Model.SubInventory> ISubInventory.Search(string key)
        {
            throw new NotImplementedException();
        }

        public IDbSet<Model.SubInventory> getDbSet()
        {
            return db.SubInventorySet;
        }

        public List<Model.SubInventory> SelectByInventory(int inventoryId)
        {
            return db.SubInventorySet.Where(si => si.InventoryID == inventoryId).ToList();
        }
    }
}
