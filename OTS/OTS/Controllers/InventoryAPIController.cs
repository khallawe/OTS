using OTS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OTS.Controllers
{
    public class InventoryAPIController : ApiController
    {
        // GET: api/InventoryAPI
        public List<Model.Inventory> Get()
        {
            OTSContext db = new OTSContext();
            
                return db.InventorySet.ToList();
            
        }

        // GET: api/InventoryAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InventoryAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/InventoryAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/InventoryAPI/5
        public void Delete(int id)
        {
        }
    }
}
