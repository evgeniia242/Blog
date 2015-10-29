namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingApplicationUserinPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "Owner_Id");
            AddForeignKey("dbo.Posts", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Owner_Id" });
            DropColumn("dbo.Posts", "Owner_Id");
        }
    }
}
