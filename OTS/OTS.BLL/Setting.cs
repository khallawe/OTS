using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;

namespace OTS.BLL
{
   public class Setting : ISetting
    {
        private static readonly ISetting dal = DataAccess.CreateInstance<ISetting>("Setting");

        /// <summary>
        /// singleton
        /// </summary>
        public static Setting Instance { get { Setting Instance = new Setting(); return Instance; } }

        public IDbSet<Model.Setting> getDbSet()
        {
            return dal.getDbSet();
        }

        public List<Model.Setting> SelectAll()
        {
            return dal.SelectAll();
        }

        public Model.Setting SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        public int Update(Model.Setting setting)
        {
            return dal.Update(setting);
        }
    }
}
