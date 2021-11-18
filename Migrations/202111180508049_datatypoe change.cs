namespace InstituteOfTechnology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypoechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "CourseStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "CourseStatus", c => c.Int(nullable: false));
        }
    }
}
