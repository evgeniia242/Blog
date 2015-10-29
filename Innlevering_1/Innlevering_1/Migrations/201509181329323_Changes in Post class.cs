namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesinPostclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostTitle");
        }
    }
}
