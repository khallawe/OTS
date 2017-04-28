using OTS.IDAL;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OTS.DAL
{
    public class Group : IGroup
    {
        OTSContext db = new OTSContext();

        public int Add(Model.Group group)
        {

            try
            {
                var existingGroup = db.GroupSet.Count(a => a.groupName == group.groupName);
                if (existingGroup == 0)
                {
                    db.GroupSet.Add(group);
                    db.SaveChanges();
                    return group.ID;

                }
                else
                    return -1;
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        

        public int Delete(int id)
        {
            Model.Group group = db.GroupSet.FirstOrDefault(x => x.ID == id);
            db.GroupSet.Remove(group);
            return db.SaveChanges();
           // return 1;
        }

        public List<Model.Group> Search(string key)
        {
            throw new NotImplementedException();
        }

        public List<Model.Group> SelectAll()
        {
            List<Model.Group> groups = db.GroupSet.ToList();
            return groups;
        }

        public Model.Group SelectOne(int id)
        {
            Model.Group group = db.GroupSet.First(x => x.ID == id);
            return group;
        }
        public IDbSet<Model.Group> getGroupsDbSet()
        {
            return db.GroupSet;
        }
        public int Update(Model.Group group)
        {
            
          
                Model.Group oldGroup = db.GroupSet.FirstOrDefault(x => x.ID == group.ID);
                oldGroup.groupName = group.groupName;
                oldGroup.ModifiedDate = group.ModifiedDate;
                oldGroup.ModifiedBy = group.ModifiedBy;
                return db.SaveChanges();
                
            
            

        
        }

        
    }
}
