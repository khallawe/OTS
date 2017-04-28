using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.IDAL;
using OTS.Model;
using OTS.DALFactory;
using System.Data.Entity;

namespace OTS.BLL
{
    public class Group : IGroup
    {
        private static readonly IGroup dal = DataAccess.CreateInstance<IGroup>("Group");

        /// <summary>
        /// singleton
        /// </summary>
        public static Group Instance { get { Group Instance = new Group(); return Instance; } }

        public int Add(Model.Group group)
        {
            return dal.Add(group);
        }

        

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public IDbSet<Model.Group> getGroupsDbSet()
        {
            return dal.getGroupsDbSet();
        }

        public List<Model.Group> Search(string key)
        {
            return dal.Search(key);
        }

        public List<Model.Group> SelectAll()
        {
            return dal.SelectAll();
        }

        public Model.Group SelectOne(int id)
        {
            return dal.SelectOne(id);
        }

        

        public int Update(Model.Group group)
        {
            return dal.Update(group);
        }
    }
}
