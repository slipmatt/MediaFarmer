using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using MediaFarmer.Context.Repositories;
using UnitOfWork;
using System.Linq;

namespace MediaFarmer.Tests.RepositoryTests
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
            repos.DownVote(2);
            Assert.IsTrue(context.Object.Votes.Count(i => i.PlayHistoryId == 2 && !i.VoteValue) == 1);
        }
        [TestMethod]
        public void ShouldUpVoteTrack()
        {
            repos.UpVote(2);
            Assert.IsTrue(context.Object.Votes.Count(i => i.PlayHistoryId == 2 && i.VoteValue) == 1);
        }

        [TestMethod]
        public void ShouldCancelUpVote()
        {
            repos.UpVote(1);
            Assert.IsTrue(context.Object.Votes.Count(i => i.PlayHistoryId == 1 && i.VoteValue)==3);
        }

        [TestMethod]
        public void ShouldCancelDownVote()
        {
            repos.DownVote(50);
            Assert.AreEqual(context.Object.Votes.Count(i => i.PlayHistoryId == 1 && i.VoteValue), 1);
        }
    }
}
