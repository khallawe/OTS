using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;
using System.Data.Entity;
using OTS.DAL;


namespace OTS.BLL
{
	public class Inventory : IInventory
	{
		private static readonly IInventory dal = DataAccess.CreateInstance<IInventory>("Inventory");

		/// <summary>
		/// singleton
		/// </summary>
		public static Inventory Instance { get { Inventory Instance = new Inventory(); return Instance; } }

		public int Add(Model.Inventory inventory)
		{
			 return dal.Add(inventory);
		
		}

		public int Delete(int inventoryID)
		{
            return dal.Delete(inventoryID);
		}

		public List<SubInventory> Search(string key)
		{
			throw new NotImplementedException();
		}

		public List<Model.Inventory> SelectAll()
		{
			return dal.SelectAll();
		}

		public Model.Inventory SelectOne(int id)
		{
            return dal.SelectOne(id);
		}

		public int Update(Model.Inventory inventory)
		{
            return dal.Update(inventory);
		}

        List<Model.SubInventory> IInventory.Search(string key)
        {
            throw new NotImplementedException();
        }


        public IDbSet<Model.Inventory> getDbSet()
        {
            return dal.getDbSet();
        }


    }
}
