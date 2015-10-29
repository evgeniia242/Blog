namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingApplicationUserinBlogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blogs", "Owner_Id");
            AddForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "Owner_Id" });
            DropColumn("dbo.Blogs", "Owner_Id");
        }
    }
}
