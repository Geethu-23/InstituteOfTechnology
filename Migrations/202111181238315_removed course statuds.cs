namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcoursestatuds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseStatus", "Students_Id", "dbo.Students");
            DropIndex("dbo.CourseStatus", new[] { "Students_Id" });
            DropTable("dbo.CourseStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CourseStatus", "Students_Id");
            AddForeignKey("dbo.CourseStatus", "Students_Id", "dbo.Students", "Id");
        }
    }
}
