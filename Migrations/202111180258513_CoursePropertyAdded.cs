namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePropertyAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Students_Id", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Students_Id" });
            AddColumn("dbo.Students", "Courses_Id", c => c.Int());
            CreateIndex("dbo.Students", "Courses_Id");
            AddForeignKey("dbo.Students", "Courses_Id", "dbo.Courses", "Id");
            DropColumn("dbo.StudentCourses", "Students_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourses", "Students_Id", c => c.Int());
            DropForeignKey("dbo.Students", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Courses_Id" });
            DropColumn("dbo.Students", "Courses_Id");
            CreateIndex("dbo.StudentCourses", "Students_Id");
            AddForeignKey("dbo.StudentCourses", "Students_Id", "dbo.Students", "Id");
        }
    }
}
