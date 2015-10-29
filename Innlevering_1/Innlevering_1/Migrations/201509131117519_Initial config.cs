namespace Innlevering_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 15),
                        BlogTitel = c.String(maxLength: 100),
                        Closed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        Blog_BlogId = c.Int(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogId)
                .Index(t => t.Blog_BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "Blog_BlogId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
