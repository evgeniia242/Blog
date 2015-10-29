using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innlevering_1.Models
{
    public class DefaultController : Controller
    {
        private ICommentRepository repository;
        private UserManager<ApplicationUser> manager;

        public DefaultController(ICommentRepository commentRepository)
        {
            this.repository = commentRepository;
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }

        public DefaultController()
        {
            this.repository = new CommentRepository();
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }
        
        // GET: Default
        public ActionResult Index(int postId)
        {
            return View(repository.GetAllCommentsByPostId(postId));
        }

        public ActionResult Add(Comment comment)
        {
            if (ModelState.IsValid)
            {
                repository.AddComment(comment);
                return RedirectToAction("Index", new { id = comment.Post.PostId});
            }
            else
                return View("Index", new { id = comment.Post.PostId });
        }
    }
}