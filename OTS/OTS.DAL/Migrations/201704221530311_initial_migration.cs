namespace OTS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        errorMsg = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExamLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        exam_ID = c.Int(),
                        question_ID = c.Int(),
                        selectedAnswer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.exam_ID)
                .ForeignKey("dbo.Question", t => t.question_ID)
                .ForeignKey("dbo.Answer", t => t.selectedAnswer_ID)
                .Index(t => t.exam_ID)
                .Index(t => t.question_ID)
                .Index(t => t.selectedAnswer_ID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        accessId = c.String(),
                        isTaken = c.Boolean(nullable: false),
                        grade = c.String(),
                        dateTaken = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.SubInventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        inventory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.inventory_ID)
                .Index(t => t.inventory_ID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        numberOfAnswers = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        subInventory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubInventory", t => t.subInventory_ID)
                .Index(t => t.subInventory_ID);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        answer = c.String(),
                        isCorrect = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.question_ID)
                .Index(t => t.question_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        userName = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        group_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.group_ID)
                .Index(t => t.group_ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        groupName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.GradingCriteria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        minVal = c.Int(nullable: false),
                        maxVal = c.Int(nullable: false),
                        grade = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                        roleDesc = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        examTime = c.Int(nullable: false),
                        maxQuestionsInSubInventories = c.Int(nullable: false),
                        minSubInventories = c.Int(nullable: false),
                        maxSubInventories = c.Int(nullable: false),
                        randomLength = c.Int(nullable: false),
                        questionGrades = c.Int(nullable: false),
                        validTimeAccess = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubInventoryExam",
                c => new
                    {
                        SubInventory_ID = c.Int(nullable: false),
                        Exam_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubInventory_ID, t.Exam_ID })
                .ForeignKey("dbo.SubInventory", t => t.SubInventory_ID, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.Exam_ID, cascadeDelete: true)
                .Index(t => t.SubInventory_ID)
                .Index(t => t.Exam_ID);
            
            CreateTable(
                "dbo.QuestionExam",
                c => new
                    {
                        Question_ID = c.Int(nullable: false),
                        Exam_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_ID, t.Exam_ID })
                .ForeignKey("dbo.Question", t => t.Question_ID, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.Exam_ID, cascadeDelete: true)
                .Index(t => t.Question_ID)
                .Index(t => t.Exam_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Group", "Role_ID", "dbo.Role");
            DropForeignKey("dbo.ExamLog", "selectedAnswer_ID", "dbo.Answer");
            DropForeignKey("dbo.ExamLog", "question_ID", "dbo.Question");
            DropForeignKey("dbo.ExamLog", "exam_ID", "dbo.Exam");
            DropForeignKey("dbo.Exam", "user_ID", "dbo.User");
            DropForeignKey("dbo.User", "group_ID", "dbo.Group");
            DropForeignKey("dbo.Question", "subInventory_ID", "dbo.SubInventory");
            DropForeignKey("dbo.QuestionExam", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.QuestionExam", "Question_ID", "dbo.Question");
            DropForeignKey("dbo.Answer", "question_ID", "dbo.Question");
            DropForeignKey("dbo.SubInventory", "inventory_ID", "dbo.Inventory");
            DropForeignKey("dbo.SubInventoryExam", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.SubInventoryExam", "SubInventory_ID", "dbo.SubInventory");
            DropIndex("dbo.QuestionExam", new[] { "Exam_ID" });
            DropIndex("dbo.QuestionExam", new[] { "Question_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "Exam_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "SubInventory_ID" });
            DropIndex("dbo.Group", new[] { "Role_ID" });
            DropIndex("dbo.User", new[] { "group_ID" });
            DropIndex("dbo.Answer", new[] { "question_ID" });
            DropIndex("dbo.Question", new[] { "subInventory_ID" });
            DropIndex("dbo.SubInventory", new[] { "inventory_ID" });
            DropIndex("dbo.Exam", new[] { "user_ID" });
            DropIndex("dbo.ExamLog", new[] { "selectedAnswer_ID" });
            DropIndex("dbo.ExamLog", new[] { "question_ID" });
            DropIndex("dbo.ExamLog", new[] { "exam_ID" });
            DropTable("dbo.QuestionExam");
            DropTable("dbo.SubInventoryExam");
            DropTable("dbo.Setting");
            DropTable("dbo.Role");
            DropTable("dbo.GradingCriteria");
            DropTable("dbo.Group");
            DropTable("dbo.User");
            DropTable("dbo.Answer");
            DropTable("dbo.Question");
            DropTable("dbo.Inventory");
            DropTable("dbo.SubInventory");
            DropTable("dbo.Exam");
            DropTable("dbo.ExamLog");
            DropTable("dbo.ErrorLog");
        }
    }
}
