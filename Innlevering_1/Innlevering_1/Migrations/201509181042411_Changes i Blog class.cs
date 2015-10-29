namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesiBlogclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogTitel", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogTitel", c => c.String(maxLength: 100));
        }
    }
}
