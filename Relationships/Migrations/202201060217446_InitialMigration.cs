namespace Relationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Grade_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Grade_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.Grade_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Grade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "Grade_Id", "dbo.Grades");
            DropForeignKey("dbo.StudentGrades", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentGrades", new[] { "Grade_Id" });
            DropIndex("dbo.StudentGrades", new[] { "Student_Id" });
            DropTable("dbo.StudentGrades");
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
        }
    }
}
