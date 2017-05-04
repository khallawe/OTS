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


        public int Add(Model.SubInventory subInventory)
        {
            using (var db = new OTSContext())
            {
                db.SubInventorySet.Add(subInventory);
                return db.SaveChanges();
            }
            

        }


        //Delete is making  is Active field==False
        public int Delete(int subInventoryID)
        {
            using ( var db = new OTSContext())
                {
                Model.SubInventory SubInventoryToDelete = db.SubInventorySet.Single(x => x.SubInventoryID == subInventoryID);
                //  db.SubInventorySet.Remove(SubInventoryToDelete);
                SubInventoryToDelete.IsActive = false;
                return db.SaveChanges();
            }
            
        }

        public List<SubInventory> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.SubInventory> SelectAll()
        {
            List<Model.SubInventory> data;
            using (var db = new OTSContext())
            {

                return data= db.SubInventorySet.Include("Inventory")
                    .Where(x => x.inventory.IsActive == true && x.IsActive == true)
                    .OrderByDescending(p => p.SubInventoryID)
                    .Take(200).ToList().ToList();
            }
        }

        public Model.SubInventory SelectOne(int id)
        {
            Model.SubInventory data;
            using (var db = new OTSContext())
            {

                data= db.SubInventorySet.Include("Inventory").Single(x => x.SubInventoryID == id);
            }
            return data;
            
        }



        public int Update(Model.SubInventory subInventory)
        {
            using (var db = new OTSContext())
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
            OTSContext db = new OTSContext();

            return db.SubInventorySet;
            
        }

        public List<Model.SubInventory> SelectByInventory(int inventoryId)
        {
            List<Model.SubInventory> data;
            using (var db = new OTSContext())
            {

                return data= db.SubInventorySet.Where(si => si.InventoryID == inventoryId).ToList();
            }
            
        }
    }
}
