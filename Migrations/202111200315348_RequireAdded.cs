namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Courses_Id" });
            DropColumn("dbo.Students", "Courses_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Courses_Id", c => c.Int());
            CreateIndex("dbo.Students", "Courses_Id");
            AddForeignKey("dbo.Students", "Courses_Id", "dbo.Courses", "Id");
        }
    }
}
