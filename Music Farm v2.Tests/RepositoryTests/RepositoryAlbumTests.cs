using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using UnitOfWork;
using MusicFarmer.Data;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryAlbumTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryAlbum repos;

        [TestInitialize]
        public void InitializeTests()
        {
             context = new Mock.Database.MockData.MockAlbumTests().MockContext;
             repos= new RepositoryAlbum(new Uow(context.Object));
        }

        [TestMethod]
        public void ShouldGet1Album()
        {
            var items = repos.GetAllAlbums();
            Assert.IsTrue(items.Count  == 1);
        }

        [TestMethod]
        public void ShouldGetAlbumId()
        {
            var items = repos.GetAlbumId("Test Album").Find(i => i.AlbumName == "Test Album");
            Assert.IsTrue(items.AlbumId == 1);
        }

        [TestMethod]
        public void ShouldGetNoFilteredItems()
        {
            var items = repos.GetFilteredAlbums("Da Album");
            Assert.IsTrue(items.Count == 0);
        }

        [TestMethod]
        public void ShouldGet1FilteredItems()
        {
            var items = repos.GetFilteredAlbums("Test");
            Assert.IsTrue(items.Count == 1);
        }
    }
}
