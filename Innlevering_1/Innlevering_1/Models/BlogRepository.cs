using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Innlevering_1.Models
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        
        public ApplicationDbContext GetContext()
        {
            return context;
        }

        public void AddBlog(Blog blog)
        {
            if(blog.BlogId == 0)
                context.Blogs.Add(blog);

            context.SaveChanges();
        }

        public void CloseBlog(int blogId)
        {
            Blog dbEntry = context.Blogs.Find(blogId);
            if (dbEntry != null)
            {
                dbEntry.Closed = true;
            }

            context.SaveChanges();
        }

        public IEnumerable<Blog> getAll()
        {
            return context.Blogs.Include(u => u.Owner);
        }
    }
}