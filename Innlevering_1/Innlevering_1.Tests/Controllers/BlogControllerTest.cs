using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Innlevering_1.Models;
using Moq;
using Innlevering_1.Controllers;
using System.Collections;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Innlevering_1.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {
        private List<Blog> testBlogs;
        private Mock<IBlogRepository> _repository;
        private UserManager<ApplicationUser> _manager;
        private Mock<IUserStore<ApplicationUser>> _iUserStore;

        [TestInitialize]
        public void SetUpContext()
        {
            //Setting up Mock repository
            _repository = new Mock<IBlogRepository>();
            _iUserStore = new Mock<IUserStore<ApplicationUser>>();
            _manager = new UserManager<ApplicationUser>(_iUserStore.Object);


            //Making List with test products
            testBlogs = new List<Blog> {
                new Blog { BlogTitel = "First test-blog", Closed = false },
                new Blog { BlogTitel = "Second test-blog", Closed = false } };
        }

        [TestMethod]
        public void IndexReturnsAllBlogs()
        {
            //Arrange
            //Defining get all method
            _repository.Setup(x => x.getAll()).Returns(testBlogs);
            //Setting up controller in Mock repository
            var controller = new BlogController(_repository.Object, _manager);

            //Act
            var result = (ViewResult)controller.Index();

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Blog));
            Assert.IsNotNull(result, "View result is null");
            var blogs = result.ViewData.Model as List<Blog>;
            Assert.AreEqual(2, blogs.Count, "Wrong number of products");
        }

        [TestMethod]
        public void CreateAddsBlog()
        {
            //Arrange
            Blog blog = new Blog { BlogTitel = "Third test-blog", Closed = false };
            var controller = new BlogController(_repository.Object, _manager);

            //Act
            ActionResult result = controller.Create(blog);

            //Assert
            _repository.Verify(b => b.AddBlog(blog));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateDoesNotAddBlog()
        {
            //Arrange
            Blog blog = new Blog { BlogTitel = "Third test-blog", Closed = false };
            var controller = new BlogController(_repository.Object, _manager);
            controller.ModelState.AddModelError("error", "error");

            //Act
            ActionResult result = controller.Create(blog);

            //Assert
            _repository.Verify(b => b.AddBlog(It.IsAny<Blog>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CanCloseBlog()
        {
            //Arrange
            _repository.Setup(p => p.getAll()).Returns(testBlogs);
            var controller = new BlogController(_repository.Object, _manager);

            //Act
            controller.Close(testBlogs[0].BlogId);

            //Assert
            _repository.Verify(p => p.CloseBlog(testBlogs[0].BlogId));
        }
    }
}

