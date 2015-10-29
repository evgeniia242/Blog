using Innlevering_1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Innlevering_1.Controllers
{
    public class CommentApiController : ApiController
    {
        private ICommentRepository repository;
        private UserManager<ApplicationUser> manager;

        public CommentApiController(ICommentRepository commentRepository, UserManager<ApplicationUser> manager)
        {
            this.repository = commentRepository;
            this.manager = manager;
        }

        public CommentApiController()
        {
            this.repository = new CommentRepository();
            this.manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.repository.GetContext()));
        }

        //GET api/Comments
        [System.Web.Http.HttpGet]
        public IEnumerable<Comment> GetComments(int postId)
        {
            IEnumerable<Comment> comments = repository.GetAllCommentsByPostId(postId);
            return comments;
        }

        //GET api/Comments
        [System.Web.Http.HttpGet]
        public IEnumerable<Comment> GetAllComments()
        {
            IEnumerable<Comment> comments = repository.GetAll();
            return comments;
        }

        //POST api/Comments
        [Authorize]
        [HttpPost]
        public HttpResponseMessage PostComment(Comment comment)
        {
            comment.Owner = manager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid && repository.AddComment(comment))
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, comment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = comment.CommentId }));
                return response;
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
