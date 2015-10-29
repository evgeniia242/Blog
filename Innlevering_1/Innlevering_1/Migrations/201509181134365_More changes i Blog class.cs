namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MorechangesiBlogclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Author", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Author", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
