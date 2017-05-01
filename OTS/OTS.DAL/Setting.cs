
using System.Collections.Generic;
using System.Linq;
using OTS.IDAL;
using System.Data.Entity;

namespace OTS.DAL
{
    class Setting : ISetting
    {
        OTSContext db = new OTSContext();

        public IDbSet<Model.Setting> getDbSet()
        {
            return db.SettingSet;
        }

        public List<Model.Setting> SelectAll()
        {
            return db.SettingSet.ToList();
        }

        public Model.Setting SelectOne(int id)
        {
            return db.SettingSet.Single(x => x.SettingID == id);
        }

        public int Update(Model.Setting setting)
        {
            var original = db.SettingSet.Find(setting.SettingID);

            if (original != null)
            {
                //db.Entry(original).CurrentValues.SetValues(setting);
                //return db.SaveChanges();
            }
            //db.SettingSet.Attach(setting);
            //db.Entry(setting).State = EntityState.Modified;
            //db.SaveChanges();
            

            return db.SaveChanges();

        }
    }
}
