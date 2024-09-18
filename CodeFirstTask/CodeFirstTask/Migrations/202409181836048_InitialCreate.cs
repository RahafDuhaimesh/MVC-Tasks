namespace CodeFirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Description = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.studentDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        NumOfSiblings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        StudentDetailsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.studentDetails", "ID", "dbo.Student");
            DropForeignKey("dbo.Course", "TeacherID", "dbo.Teacher");
            DropIndex("dbo.studentDetails", new[] { "ID" });
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropTable("dbo.Student");
            DropTable("dbo.studentDetails");
            DropTable("dbo.Teacher");
            DropTable("dbo.Course");
        }
    }
}
