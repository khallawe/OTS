namespace OTS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        QuestionID = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        SubInventoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.SubInventory", t => t.SubInventoryID, cascadeDelete: true)
                .Index(t => t.SubInventoryID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        accessId = c.String(),
                        studentId = c.Int(nullable: false),
                        isTaken = c.Boolean(nullable: false),
                        grade = c.String(),
                        dateTaken = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.studentId, cascadeDelete: true)
                .Index(t => t.studentId);
            
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
                        IsActive = c.Boolean(nullable: false),
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
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        studentID = c.Int(nullable: false),
                        studentName = c.String(nullable: false),
                        studentEmail = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        IsActive = c.Boolean(nullable: false),
                        exam_ID = c.Int(),
                        question_QuestionID = c.Int(),
                        selectedAnswer_AnswerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.exam_ID)
                .ForeignKey("dbo.Question", t => t.question_QuestionID)
                .ForeignKey("dbo.Answer", t => t.selectedAnswer_AnswerID)
                .Index(t => t.exam_ID)
                .Index(t => t.question_QuestionID)
                .Index(t => t.selectedAnswer_AnswerID);
            
            CreateTable(
                "dbo.GradingCriteria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        minVal = c.Int(nullable: false),
                        maxVal = c.Int(nullable: false),
                        grade = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Group_ID = c.Int(nullable: false, identity: true),
                        groupName = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Group_ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        roleName = c.String(nullable: false),
                        roleDesc = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.Group_ID, cascadeDelete: true)
                .Index(t => t.Group_ID);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        ExamTime = c.Int(nullable: false),
                        MaxQuestionsInSubInventories = c.Int(nullable: false),
                        MinSubInventories = c.Int(nullable: false),
                        MaxSubInventories = c.Int(nullable: false),
                        RandomLength = c.Int(nullable: false),
                        QuestionGrades = c.Int(nullable: false),
                        ValidTimeAccess = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
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
                "dbo.ExamQuestion",
                c => new
                    {
                        Exam_ID = c.Int(nullable: false),
                        Question_QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exam_ID, t.Question_QuestionID })
                .ForeignKey("dbo.Exam", t => t.Exam_ID, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_QuestionID, cascadeDelete: true)
                .Index(t => t.Exam_ID)
                .Index(t => t.Question_QuestionID);
            
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
            DropForeignKey("dbo.User", "Group_ID", "dbo.Group");
            DropForeignKey("dbo.RoleGroup", "Group_Group_ID", "dbo.Group");
            DropForeignKey("dbo.RoleGroup", "Role_ID", "dbo.Role");
            DropForeignKey("dbo.ExamLog", "selectedAnswer_AnswerID", "dbo.Answer");
            DropForeignKey("dbo.ExamLog", "question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.ExamLog", "exam_ID", "dbo.Exam");
            DropForeignKey("dbo.Exam", "studentId", "dbo.Student");
            DropForeignKey("dbo.ExamQuestion", "Question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.ExamQuestion", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.Question", "SubInventoryID", "dbo.SubInventory");
            DropForeignKey("dbo.SubInventory", "InventoryID", "dbo.Inventory");
            DropForeignKey("dbo.SubInventoryExam", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.SubInventoryExam", "SubInventory_SubInventoryID", "dbo.SubInventory");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropIndex("dbo.RoleGroup", new[] { "Group_Group_ID" });
            DropIndex("dbo.RoleGroup", new[] { "Role_ID" });
            DropIndex("dbo.ExamQuestion", new[] { "Question_QuestionID" });
            DropIndex("dbo.ExamQuestion", new[] { "Exam_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "Exam_ID" });
            DropIndex("dbo.SubInventoryExam", new[] { "SubInventory_SubInventoryID" });
            DropIndex("dbo.User", new[] { "Group_ID" });
            DropIndex("dbo.ExamLog", new[] { "selectedAnswer_AnswerID" });
            DropIndex("dbo.ExamLog", new[] { "question_QuestionID" });
            DropIndex("dbo.ExamLog", new[] { "exam_ID" });
            DropIndex("dbo.SubInventory", new[] { "InventoryID" });
            DropIndex("dbo.Exam", new[] { "studentId" });
            DropIndex("dbo.Question", new[] { "SubInventoryID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropTable("dbo.RoleGroup");
            DropTable("dbo.ExamQuestion");
            DropTable("dbo.SubInventoryExam");
            DropTable("dbo.Setting");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Group");
            DropTable("dbo.GradingCriteria");
            DropTable("dbo.ExamLog");
            DropTable("dbo.ErrorLog");
            DropTable("dbo.Student");
            DropTable("dbo.Inventory");
            DropTable("dbo.SubInventory");
            DropTable("dbo.Exam");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
