using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Innlevering_1.Models
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ApplicationDbContext GetContext()
        {
            return context;
        }

        public void AddPost(Post post, int blogId)
        {
            if (post.PostId == 0)
            {
                post.Blog = context.Blogs.Find(blogId);
                post.Date = DateTime.Now;
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.PostId);
                if (dbEntry != null)
                {
                    dbEntry.PostTitle = post.PostTitle;
                    dbEntry.Text = post.Text;
                }
            }

            context.SaveChanges();
        }

        public Post DeletePost(Post post)
        {
            Post dbEntry = context.Posts.Find(post.PostId);
            if(dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public IEnumerable<Post> GetAllPostByBlogId(int blogId)
        {
            IEnumerable<Post> posts = context.Posts.Include(u => u.Owner).Include(b => b.Blog).Where(p => p.Blog.BlogId == blogId);
            return posts;
        }
    }
}
