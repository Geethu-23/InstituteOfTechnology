namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentCourseuncomented : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCourses", "Students_Id", c => c.Int());
            CreateIndex("dbo.StudentCourses", "Students_Id");
            AddForeignKey("dbo.StudentCourses", "Students_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Students_Id", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Students_Id" });
            DropColumn("dbo.StudentCourses", "Students_Id");
        }
    }
}
