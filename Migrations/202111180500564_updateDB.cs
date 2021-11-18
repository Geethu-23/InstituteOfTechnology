namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseStatus", "Students_Id", c => c.Int());
            CreateIndex("dbo.CourseStatus", "Students_Id");
            AddForeignKey("dbo.CourseStatus", "Students_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseStatus", "Students_Id", "dbo.Students");
            DropIndex("dbo.CourseStatus", new[] { "Students_Id" });
            DropColumn("dbo.CourseStatus", "Students_Id");
        }
    }
}
