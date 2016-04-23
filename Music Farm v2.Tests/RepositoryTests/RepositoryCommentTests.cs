using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using UnitOfWork;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using System.Linq;
using System.Web;
using System.IO;
using MediaFarmer.Tests.RepositoryTests.Helpers;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryCommentTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryComment repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockCommentTests().MockContext;
            repos = new RepositoryComment(new Uow(context.Object));
            // Step 1: Setup the HTTP Request
            var HttpRequest = new HttpRequest("", "http://localhost/", "");
            HttpRequest.AddServerVariable("REMOTE_HOST", "ACER\\ASPIRE");
            // Step 2: Setup the HTTP Response
            var httpResponce = new HttpResponse(new StringWriter());

            // Step 3: Setup the Http Context
            var httpContext = new HttpContext(HttpRequest, httpResponce);
            // Step 4: Assign the Context
            HttpContext.Current = httpContext;
        }

        [TestMethod]
        public void ShouldGetAllCommentsOfTrack()
        {
            var item = repos.GetComments(1);
            Assert.IsTrue(item.Count == 1);
        }
        
        [TestMethod]
        public void ShouldAddAComment()
        {
             CommentViewModel item = new CommentViewModel
            {
                CommentId = 1,
                CommentText = "This Rocks",
                PlayHistoryId = 1,
                UserId = 1,
                UserName = "ACER\\Aspire"
            };
            repos.AddComment(item);
            //var items = repos.GetComments(1);
            //Assert.IsTrue(items.Count == 2);
            Assert.IsTrue(context.Object.Comments.Count(i => i.PlayHistoryId == 1) == 2);
        }

        [TestMethod]
        public void ShouldGet1Comment()
        {
            var items = repos.GetComments(1);
            Assert.IsTrue(items.Count == 1);
        }
    }
}
