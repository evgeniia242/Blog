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
    public class BlogController : Controller
    {
        private IBlogRepository repository;
        private UserManager<ApplicationUser> manager;
        // GET: Blog

        public BlogController(IBlogRepository blogRepository, UserManager<ApplicationUser> manager)
        {
            this.repository = blogRepository;
            this.manager = manager;
        }

        public BlogController()
        {
            this.repository = new BlogRepository();
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }

        public ActionResult Index()
        {
            IEnumerable<Blog> blogs = repository.getAll();
            return View(blogs);
        }

        [Authorize]
        public ViewResult Create()
        {
            return View(new Blog());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                blog.Owner = user;
                repository.AddBlog(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogTitel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(blog);
            }
        }

        [Authorize]
        public ActionResult Close(int id)
        {
            Blog blog = repository.getAll().FirstOrDefault(b => b.BlogId == id);
            repository.CloseBlog(id);
            TempData["message"] = string.Format("'{0}' was closed", blog.BlogTitel);
            return RedirectToAction("Index");
        }
    }
}