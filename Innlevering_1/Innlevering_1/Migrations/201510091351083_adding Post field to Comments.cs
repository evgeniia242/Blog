namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPostfieldtoComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropColumn("dbo.Comments", "Post_PostId");
        }
    }
}
