namespace BellordPlants.mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            AlterColumn("dbo.Answers", "AnswerAuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "AnswerAuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionID");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
