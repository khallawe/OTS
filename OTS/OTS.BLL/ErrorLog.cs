using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;

namespace OTS.BLL
{
   public class ErrorLog : IErrorLog
    {
        private static readonly IErrorLog dal = DataAccess.CreateInstance<IErrorLog>("ErrorLog");

        /// <summary>
        /// singleton
        /// </summary>
        public static ErrorLog Instance { get { ErrorLog Instance = new ErrorLog(); return Instance; } }


        public int Add(Model.ErrorLog error)
        {
            return dal.Add(error);
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
