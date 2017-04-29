namespace OTS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        errorMsg = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
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
                        SubInventoryID = c.Int(nullable: false, identity: true),
                        InventoryID = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.SubInventoryID)
                .ForeignKey("dbo.Inventory", t => t.InventoryID, cascadeDelete: true)
                .Index(t => t.InventoryID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryID);
            
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
                        subInventory_SubInventoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubInventory", t => t.subInventory_SubInventoryID)
                .Index(t => t.subInventory_SubInventoryID);
            
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
                        Group_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.Group_ID, cascadeDelete: true)
                .Index(t => t.Group_ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Group_ID = c.Int(nullable: false, identity: true),
                        groupName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Group_ID);
            
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
                        SubInventory_SubInventoryID = c.Int(nullable: false),
                        Exam_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubInventory_SubInventoryID, t.Exam_ID })
                .ForeignKey("dbo.SubInventory", t => t.SubInventory_SubInventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Exam", t => t.Exam_ID, cascadeDelete: true)
                .Index(t => t.SubInventory_SubInventoryID)
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
            
            CreateTable(
                "dbo.RoleGroup",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Group_Group_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Group_Group_ID })
                .ForeignKey("dbo.Role", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.Group_Group_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Group_Group_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamLog", "selectedAnswer_ID", "dbo.Answer");
            DropForeignKey("dbo.ExamLog", "question_ID", "dbo.Question");
            DropForeignKey("dbo.ExamLog", "exam_ID", "dbo.Exam");
            DropForeignKey("dbo.Exam", "user_ID", "dbo.User");
            DropForeignKey("dbo.User", "Group_ID", "dbo.Group");
            DropForeignKey("dbo.RoleGroup", "Group_Group_ID", "dbo.Group");
            DropForeignKey("dbo.RoleGroup", "Role_ID", "dbo.Role");
            DropForeignKey("dbo.Question", "subInventory_SubInventoryID", "dbo.SubInventory");
            DropForeignKey("dbo.QuestionExam", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.QuestionExam", "Question_ID", "dbo.Question");
            DropForeignKey("dbo.Answer", "question_ID", "dbo.Question");
            DropForeignKey("dbo.SubInventory", "InventoryID", "dbo.Inventory");
            DropForeignKey("dbo.SubInventoryExam", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.SubInventoryExam", "SubInventory_SubInventoryID", "dbo.SubInventory");
            DropIndex("dbo.RoleGroup", new[] { "Group_Group_ID" });
            DropIndex("dbo.RoleGroup", new[] { "Role_ID" });
            DropIndex("dbo.QuestionExam", new[] { "Exam_ID" });
            DropIndex("dbo.QuestionExam", new[] { "Question_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "Exam_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "SubInventory_SubInventoryID" });
            DropIndex("dbo.User", new[] { "Group_ID" });
            DropIndex("dbo.Answer", new[] { "question_ID" });
            DropIndex("dbo.Question", new[] { "subInventory_SubInventoryID" });
            DropIndex("dbo.SubInventory", new[] { "InventoryID" });
            DropIndex("dbo.Exam", new[] { "user_ID" });
            DropIndex("dbo.ExamLog", new[] { "selectedAnswer_ID" });
            DropIndex("dbo.ExamLog", new[] { "question_ID" });
            DropIndex("dbo.ExamLog", new[] { "exam_ID" });
            DropTable("dbo.RoleGroup");
            DropTable("dbo.QuestionExam");
            DropTable("dbo.SubInventoryExam");
            DropTable("dbo.Setting");
            DropTable("dbo.GradingCriteria");
            DropTable("dbo.Role");
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
