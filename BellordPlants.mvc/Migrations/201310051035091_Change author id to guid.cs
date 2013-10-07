namespace BellordPlants.mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeauthoridtoguid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "AnswerAuthorId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Questions", "QuestionAuthorID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "QuestionAuthorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "AnswerAuthorId", c => c.Int(nullable: false));
        }
    }
}
