using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Innlevering_1.Models;
using Moq;
using System.Collections.Generic;
using Innlevering_1.Controllers;
using System.Web.Mvc;
using System.Collections;
using Microsoft.AspNet.Identity;

namespace Innlevering_1.Tests.Controllers
{
    [TestClass]
    public class PostControllerTest
    {
        private List<Post> testPosts;
        private Mock<IPostRepository> _repository;
        private UserManager<ApplicationUser> _manager;
        private Mock<IUserStore<ApplicationUser>> _iUserStore;

        [TestInitialize]
        public void SetUpContext()
        {
            //Setting up Mock repository
            _repository = new Mock<IPostRepository>();
            _iUserStore = new Mock<IUserStore<ApplicationUser>>();
            _manager = new UserManager<ApplicationUser>(_iUserStore.Object);

            //Making List with test products
            testPosts = new List<Post> {
                new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime()},
                new Post { PostId = 2, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #2", Text = "Second test-post", Date = new DateTime()}
                /*new Post { PostId = 3, Blog = new Blog { BlogId = 2, Author = "Brice Lambson", BlogTitel = "Second test-blog", Closed = false }, PostTitle = "Post #3", Text = "Third test-post", Date = new DateTime() }*/ };
        }

        [TestMethod]
        public void IndexReturnsAllBlogPosts()
        {
            //Arrange
            //Defining get all method
            _repository.Setup(p => p.GetAllPostByBlogId(1)).Returns(testPosts);
            //Setting up controller in Mock repository
            var controller = new PostController(_repository.Object, _manager);

            //Act
            var result = (ViewResult)controller.Index(1);

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Post));
            Assert.IsNotNull(result, "View result is null");
            var posts = result.ViewData.Model as List<Post>;
            Assert.AreEqual(2, posts.Count, "Wrong number of posts");
        }

        [TestMethod]
        public void CanUpdatePost()
        {
            //Arrange
            _repository.Setup(p => p.GetAllPostByBlogId(1)).Returns(testPosts);
            PostController controller = new PostController(_repository.Object, _manager);

            //Act
            Post firstPost = (Post)controller.Edit(1).ViewData.Model;
            Post secondPost = (Post)controller.Edit(2).ViewData.Model;

            //Assert
            Assert.AreEqual(1, firstPost.PostId);
            Assert.AreEqual(2, secondPost.PostId);
        }

        [TestMethod]
        public void CanNotUpdatePost()
        {
            //Arrange
            _repository.Setup(p => p.GetAllPostByBlogId(1)).Returns(testPosts);
            PostController controller = new PostController(_repository.Object, _manager);

            //Act
            Post result = (Post)controller.Edit(4).ViewData.Model;

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CreateAddsPost()
        {
            //Arrange
            Post post = new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime() };
            var controller = new PostController(_repository.Object, _manager);

            //Act
            ActionResult result = controller.Edit(post);

            //Assert
            _repository.Verify(b => b.AddPost(post, 1));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateDoesNotAddPost()
        {
            //Arrange
            Post post = new Post { PostId = 1, Blog = new Blog { BlogId = 1, BlogTitel = "First test-blog", Closed = false }, PostTitle = "Post #1", Text = "First test-post", Date = new DateTime() };
            var controller = new PostController(_repository.Object, _manager);
            controller.ModelState.AddModelError("error", "error");

            //Act
            ActionResult result = controller.Edit(post);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
