﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Farm_v2.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Music_Farm_v2.Tests.RepositoryTests
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

        
    }
}