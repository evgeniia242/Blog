using Innlevering_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innlevering_1.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository repository;
        private UserManager<ApplicationUser> manager;
        private static int postId;
        // GET: Post

        public CommentController(ICommentRepository repository, UserManager<ApplicationUser> manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public CommentController()
        {
            this.repository = new CommentRepository();
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }

        // GET: Comment
        public ActionResult Index(int id)
        {
            postId = id;
            IEnumerable<Comment> postComments = repository.GetAllCommentsByPostId(id);
            return View(postComments);
        }
    }
}