namespace BellordPlants.mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeddateonEndTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskListItems", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskListItems", "EndTime", c => c.String(nullable: false));
        }
    }
}
