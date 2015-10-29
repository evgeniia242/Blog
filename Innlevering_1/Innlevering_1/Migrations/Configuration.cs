namespace Innlevering_1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Innlevering_1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Innlevering_1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Blogs.AddOrUpdate(
              b => b.BlogTitel,
              new Blog { BlogTitel = "First test-blog", Closed = false },
              new Blog { BlogTitel = "Second test-blog", Closed = false }
            );

            /*context.Posts.AddOrUpdate(
              p => p.Author,
              new Post { Blog = 1, text = "Test post #1 (blog #1, Andrew Peters" },
              new Post { Blog = 2, text = "Test post #2 (blog #1, Andrew Peters" },
              new Post { Blog = 1, text = "Test post #1 (blog #2, Brice Lambson" },
              new Post { Blog = 2, text = "Test post #2 (blog #2, Brice Lambson" }
            );*/
        }
    }
}
