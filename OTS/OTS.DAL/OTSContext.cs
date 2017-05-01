using OTS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OTS.DAL
{
    public class OTSContext : DbContext
    {
        public OTSContext() : base("OTS")
        {
            Database.SetInitializer<OTSContext>(null);
        }

        #region
        public IDbSet<Model.Exam> ExamSet { get; set; }
        public IDbSet<Model.ExamLog> ExamLogSet { get; set; }
        //public IDbSet<Model.ExamQuestion> ExamQuestionSet { get; set; }
        public IDbSet<Model.GradingCriteria> GradingCriteriaSet { get; set; }
        public IDbSet<Model.Inventory> InventorySet { get; set; }
        public IDbSet<Model.Question> QuestionSet { get; set; }
        public IDbSet<Model.Answer> AnswerSet { get; set; }
        public IDbSet<Model.Student> StudentSet { get; set; }
        public IDbSet<Model.Setting> SettingSet { get; set; }
        public IDbSet<Model.SubInventory> SubInventorySet { get; set; }
        public IDbSet<Model.User> UserSet { get; set; }
        public IDbSet<Model.Group> GroupSet { get; set; }
        public IDbSet<Model.Role> RoleSet { get; set; }
        //public IDbSet<Model.GroupRoles> GroupRolesSet { get; set; }
        public IDbSet<Model.ErrorLog> ErrorLogSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modeBuilder)
        {
            modeBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        internal void Entry(object groupSet)
        {
            throw new NotImplementedException();
        }
    }
}
