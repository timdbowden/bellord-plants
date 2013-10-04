namespace BellordPlants.mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedanswerpartialviews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "AnswerAuthor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionAuthor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Answers", new[] { "AnswerAuthor_Id" });
            DropIndex("dbo.Answers", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionAuthor_Id" });
            RenameColumn(table: "dbo.Answers", name: "Question_QuestionId", newName: "QuestionID");
            AddColumn("dbo.Answers", "AnswerAuthorID", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "QuestionAuthorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionID");
            AddForeignKey("dbo.Answers", "QuestionID", "dbo.Questions", "QuestionId", cascadeDelete: true);
            DropColumn("dbo.Answers", "AnswerAuthor_Id");
            DropColumn("dbo.Questions", "QuestionAuthor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "QuestionAuthor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Answers", "AnswerAuthor_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            AlterColumn("dbo.Answers", "QuestionID", c => c.Int());
            DropColumn("dbo.Questions", "QuestionAuthorID");
            DropColumn("dbo.Answers", "AnswerAuthorID");
            RenameColumn(table: "dbo.Answers", name: "QuestionID", newName: "Question_QuestionId");
            CreateIndex("dbo.Questions", "QuestionAuthor_Id");
            CreateIndex("dbo.Answers", "Question_QuestionId");
            CreateIndex("dbo.Answers", "AnswerAuthor_Id");
            AddForeignKey("dbo.Questions", "QuestionAuthor_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Answers", "AnswerAuthor_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
