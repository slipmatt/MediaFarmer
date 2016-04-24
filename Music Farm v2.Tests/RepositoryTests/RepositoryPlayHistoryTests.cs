using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using MediaFarmer.Tests.RepositoryTests.Helpers;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryPlayHistoryTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryPlayHistory repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockPlayHistoryTests().MockContext;
            repos = new RepositoryPlayHistory(new Uow(context.Object));
            MockIIS.MockIISHost();
        }

        [TestMethod]
        public void ShouldGetCurrentlyQueuedTracks()
        {
            var items = repos.GetCurrentlyQueued();
            Assert.IsTrue(items.Count==2);
        }

        [TestMethod]
        public void ShouldGetCurrentlyPlayingTrack()
        {
            var items = repos.GetCurrentlyPlaying();
            Assert.IsTrue(items.Count == 1);
        }

        [TestMethod]
        public void ShouldGetPlayCountOfTrack()
        {
            var items = repos.GetPlayCount(1);
            Assert.IsTrue(items.Count == 2);
        }

        [TestMethod]
        public void ShouldQueueTrack()
        {
            repos.Queue(65445);
            Assert.IsTrue(context.Object.PlayHistories.Count(i=>!i.IsPlaying && !i.PlayCompleted) == 3);
        }

        [TestMethod]
        public void ShouldCheckIfTrackIsQueued()
        {
            bool _IsQueued=repos.IsQueued(1);
            Assert.IsTrue(_IsQueued);
        }

        [TestMethod]
        public void ShouldCheckIfTrackIsNotQueued()
        {
            bool _IsQueued = repos.IsQueued(65442);
            Assert.IsFalse(_IsQueued);
        }
    }
}
