using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using Music_Farm_v2.Context.Repositories;
using UnitOfWork;

namespace Music_Farm_v2.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryVoteTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryVote repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockVoteTests().MockContext;
            repos = new RepositoryVote(new Uow(context.Object));
        }
        [TestMethod]
        public void ShouldGetUpVotesOfTrack()
        {
            var items = repos.GetUpVotes(1);
            Assert.IsTrue(items.Count == 3);
        }

        [TestMethod]
        public void ShouldGetDownVotesOfTrack()
        {
            var items = repos.GetDownVotes(1);
            Assert.IsTrue(items.Count == 1);
        }

        [TestMethod]
        public void ShouldGetAllVotesOfTrack()
        {
            var items = repos.GetVotes(1);
            Assert.IsTrue(items.Count == 4);
        }
        [TestMethod]
        public void ShouldDownVoteTrack()
        {
            repos.DownVote(1);
            var items = repos.GetDownVotes(1);
            Assert.IsTrue(items.Count == 2);
        }

        [TestMethod]
        public void ShouldUpVoteTrack()
        {
            repos.UpVote(1);
            var items = repos.GetUpVotes(1);
            Assert.IsTrue(items.Count == 4);
        }
    }
}
