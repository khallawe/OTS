using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    interface IErrorLog
    {
        int Add(IErrorLog error);
        List<ErrorLog> Search(string key);
        List<ErrorLog> SelectAll();

    }
}
