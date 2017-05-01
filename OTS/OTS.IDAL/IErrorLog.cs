using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
    public interface IErrorLog
    {
        int Add(ErrorLog error);
        List<ErrorLog> Search(string key);
        List<ErrorLog> SelectAll();

    }
}
