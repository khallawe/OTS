using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Model
{
    public class OTSContext : DbContext
    {
        public OTSContext() : base("OTS")
        {
            Database.SetInitializer<OTSContext>(null);
        }

        #region
        public IDbSet<Exam> ExamSet { get; set; }
        public IDbSet<ExamLog> ExamLogSet { get; set; }
        public IDbSet<ExamQuestion> ExamQuestionSet { get; set; }
        public IDbSet<GradingCriteria> GradingCriteriaSet { get; set; }
        public IDbSet<Inventory> InventorySet { get; set; }
        public IDbSet<Question> QuestionSet { get; set; }
        public IDbSet<Setting> SettingSet { get; set; }
        public IDbSet<SubInventory> SubInventorySet { get; set; }
        public IDbSet<User> UserSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modeBuilder)
        {
            modeBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }
    }
}
