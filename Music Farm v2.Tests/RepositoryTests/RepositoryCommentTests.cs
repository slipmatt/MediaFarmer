using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using UnitOfWork;
using Music_Farm_v2.Context.Repositories;
using Music_Farm_v2.ViewModels;

namespace Music_Farm_v2.Tests.RepositoryTests
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
                UserId = 1
            };
            repos.AddComment(item);
            var items = repos.GetComments(1);
            Assert.IsTrue(items.Count == 2);
        }
    }
}
