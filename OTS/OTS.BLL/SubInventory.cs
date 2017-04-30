using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;
using System.Data.Entity;

namespace OTS.BLL
{
   public class SubInventory :ISubInventory
    {
        private static readonly ISubInventory dal = DataAccess.CreateInstance<ISubInventory>("SubInventory");

        /// <summary>
        /// singleton
        /// </summary>
        public static SubInventory Instance { get { SubInventory Instance = new SubInventory(); return Instance; } }

        public int Add(Model.SubInventory subInventory)
        {
            return dal.Add(subInventory);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public IDbSet<Model.SubInventory> getDbSet()
        {
            return dal.getDbSet();
        }

        public List<Model.SubInventory> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.SubInventory> SelectAll()
        {
            return dal.SelectAll();
        }

        public List<Model.SubInventory> SelectByInventory(int inventoryId)
        {
            return dal.SelectByInventory(inventoryId);
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

        public Model.SubInventory SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        public int Update(Model.SubInventory subInventory)
        {
            return dal.Update(subInventory);
        }
    }
}
