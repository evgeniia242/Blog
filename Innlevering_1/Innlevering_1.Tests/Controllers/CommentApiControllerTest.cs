using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Innlevering_1.Models;
using Moq;
using Microsoft.AspNet.Identity;
using Innlevering_1.Controllers;
using System.Net.Http;

namespace Innlevering_1.Tests.Controllers
{
    [TestClass]
    public class CommentApiControllerTest
    {
        private List<Comment> testComments;
        private Mock<ICommentRepository> _repository;
        private UserManager<ApplicationUser> _manager;
        private Mock<IUserStore<ApplicationUser>> _iUserStore;

        [TestInitialize]
        public void SetUpContext()
        {
            //Setting up Mock repository
            _repository = new Mock<ICommentRepository>();
            _iUserStore = new Mock<IUserStore<ApplicationUser>>();
            _manager = new UserManager<ApplicationUser>(_iUserStore.Object);

            //Making List with test products
            testComments = new List<Comment> {
                new Comment {CommentId = 1, Post = new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime()}, Text = "Test-comment #1", Date = new DateTime() },
                new Comment {CommentId = 2, Post = new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime()}, Text = "Test-comment #2", Date = new DateTime() },
                new Comment {CommentId = 3, Post = new Post { PostId = 2, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #2", Text = "Second test-post", Date = new DateTime()}, Text = "Test-comment #3", Date = new DateTime()} };
        }

        [TestMethod]
        public void GetAllCommnets()
        {
            //Arrange
            //Defining get all method
            _repository.Setup(c => c.GetAll()).Returns(testComments);
            //Setting up controller in Mock repository
            var controller = new CommentApiController(_repository.Object, _manager);

            var result = controller.GetAllComments() as List<Comment>;
            Assert.AreEqual(testComments.Count, result.Count);
        }

        //[TestMethod]
        /*public void GetCommnets()
        {
            //Arrange
            //Defining get all method
            _repository.Setup(c => c.GetAll()).Returns(testComments);
            //Setting up controller in Mock repository
            var controller = new CommentApiController(_repository.Object, _manager);

            var result = controller.GetComments(1) as List<Comment>;
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void PostCommnet()
        {
            //Arrange
            //Defining get all method
            _repository.Setup(c => c.GetAll()).Returns(testComments);
            //Setting up controller in Mock repository
            var controller = new CommentApiController(_repository.Object, _manager);

            var result = controller.PostComment(new Comment { CommentId = 4, Post = new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime() }, Text = "Test-comment #4", Date = new DateTime() }) as HttpResponseMessage;
            Assert.AreEqual(201, result.StatusCode);
        */
    }
}
