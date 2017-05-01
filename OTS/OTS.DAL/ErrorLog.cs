using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;

namespace OTS.DAL
{
    class ErrorLog : IErrorLog
    {
        OTSContext db = new OTSContext();
    

        public int Add(Model.ErrorLog error)
        {
            db.ErrorLogSet.Add(error);
           return db.SaveChanges();
        }

        public List<Model.ErrorLog> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.ErrorLog> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
