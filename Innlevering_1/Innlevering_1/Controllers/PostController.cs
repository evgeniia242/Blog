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
    public class PostController : Controller
    {
        private IPostRepository repository;
        private UserManager<ApplicationUser> manager;
        private static int blogId;
        // GET: Post

        public PostController(IPostRepository repository, UserManager<ApplicationUser> manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public PostController()
        {
            this.repository = new PostRepository();
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }

        public ActionResult Index(int id)
        {
            blogId = id;
            IEnumerable<Post> blogPosts = repository.GetAllPostByBlogId(id);
            return View(blogPosts);
        }

        [Authorize]
        public ViewResult Edit(int id)
        {
            Post post = repository.GetAllPostByBlogId(blogId).FirstOrDefault(p => p.PostId == id);
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                post.Owner = user;
                repository.AddPost(post, blogId);
                TempData["message"] = string.Format("'{0}' has been saved", post.PostTitle);
                return RedirectToAction("Index", new { id = blogId });
            }
            else
            {
                return View(post);
            }
        }

        [Authorize]
        public ViewResult Create()
        {
            return View("Edit", new Post());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Post post = repository.GetAllPostByBlogId(blogId).FirstOrDefault(p => p.PostId == id);
            repository.DeletePost(post);
            TempData["message"] = string.Format("'{0}' was deleted", post.PostTitle);
            return RedirectToAction("Index", new { id = blogId });
        }
    }
}