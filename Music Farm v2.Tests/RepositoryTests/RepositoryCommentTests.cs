using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using UnitOfWork;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using System.Linq;
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
            MockIIS.MockIISHost();
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
                UserName = "acer\\aspire"
            };
            repos.AddComment(item);
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
