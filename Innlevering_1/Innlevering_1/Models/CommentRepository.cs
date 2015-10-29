using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Innlevering_1.Models
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ApplicationDbContext GetContext()
        {
            return context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments.Include(u => u.Owner).Include(p => p.Post);
        }

        public IEnumerable<Comment> GetAllCommentsByPostId(int postId)
        {
            return context.Comments.Include(u => u.Owner).Include(p => p.Post).Where(p => p.Post.PostId == postId);
        }

        public bool AddComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            context.Comments.Add(comment);

            context.SaveChanges();

            return true;
        }
    }
}