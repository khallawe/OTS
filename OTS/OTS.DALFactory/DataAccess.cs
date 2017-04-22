using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OTS.DALFactory
{
    public class DataAccess
    {
    
        static string path = ConfigurationManager.AppSettings["PC.Provider"].ToString();

        public static T CreateInstance<T>(string className)
        {
            try

            {
                string fullClassName = string.Format("{0}.{1}", path, className);
                return (T)Assembly.Load(path).CreateInstance(fullClassName);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
