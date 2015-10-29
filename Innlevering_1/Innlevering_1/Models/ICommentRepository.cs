using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Innlevering_1.Models
{
    public interface ICommentRepository
    {
        ApplicationDbContext GetContext();
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetAllCommentsByPostId(int blogId);
        bool AddComment(Comment comment);
    }
}
