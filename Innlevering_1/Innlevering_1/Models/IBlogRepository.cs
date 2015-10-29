using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innlevering_1.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> getAll();
        void AddBlog(Blog blog);
        void CloseBlog(int blogId);
        ApplicationDbContext GetContext();
    }
}
