using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innlevering_1.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPostByBlogId(int blogId);
        void AddPost(Post post, int blogId);
        Post DeletePost(Post post);
        ApplicationDbContext GetContext();
    }
}
