using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Farm_v2.Context.Repositories;
using Music_Farm_v2.ViewModels;
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
    public class RepositoryTrackTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryTrack repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockTrackTests().MockContext;
            repos = new RepositoryTrack(new Uow(context.Object));
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByName()
        {
           List<TrackViewModel> _Track= repos.SearchTrackByName("Track1");
            var _TrackId = _Track.Find(i => i.TrackName == "Track1").TrackId;
            Assert.AreEqual(1, _TrackId);
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByAlbumName()
        {
            List<TrackViewModel> _Track = repos.SearchTrackByAlbumName("TestAlbum");
            Assert.IsTrue(_Track.Count == 3);
        }
        [TestMethod]
        public void ShouldGetAllFilteredTracksByArtistName()
        {
            List<TrackViewModel> _Track = repos.SearchTrackByArtistName("Artist 1");
            Assert.IsTrue(_Track.Count == 2);
        }
    }
}
