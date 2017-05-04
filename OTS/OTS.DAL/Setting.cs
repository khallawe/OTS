
using System.Collections.Generic;
using System.Linq;
using OTS.IDAL;
using System.Data.Entity;

namespace OTS.DAL
{
    class Setting : ISetting
    {
        

        public IDbSet<Model.Setting> getDbSet()
        {
            OTSContext db = new OTSContext();
            return db.SettingSet;
        }

        public List<Model.Setting> SelectAll()
        {
            List<Model.Setting> data;

            using (var db = new OTSContext())
            {
                return data= db.SettingSet.ToList();
            }
        }

        public Model.Setting SelectOne(int id)
        {
            Model.Setting data;

            using (var db = new OTSContext())
            {
                return data= db.SettingSet.Single(x => x.SettingID == id);
            }
        }

        public int Update(Model.Setting setting)
        {
            using (var db = new OTSContext())
            {
                var original = db.SettingSet.Find(setting.SettingID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(setting);
                    return db.SaveChanges();
                }
                //db.SettingSet.Attach(setting);
                //db.Entry(setting).State = EntityState.Modified;
                //db.SaveChanges();


                return db.SaveChanges();
            }

        }
    }
}
