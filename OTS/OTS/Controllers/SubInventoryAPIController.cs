using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTS.Controllers
{
    public class SubInventoryAPIController : ApiController
    {
        // GET: api/SubInventoryAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SubInventoryAPI/5
        public IEnumerable<Model.SubInventory> Get(int id)
        {
            DAL.OTSContext db = new DAL.OTSContext();
            

                return db.SubInventorySet.Where(x => x.InventoryID == id).ToList();
            
        }

        // POST: api/SubInventoryAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SubInventoryAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubInventoryAPI/5
        public void Delete(int id)
        {
        }
    }
}
