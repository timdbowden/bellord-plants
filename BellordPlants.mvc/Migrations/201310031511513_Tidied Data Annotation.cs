namespace BellordPlants.mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TidiedDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskLists", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskLists", "Description");
        }
    }
}
