using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Farm_v2.Context.Repositories;
using UnitOfWork;

namespace Music_Farm_v2.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryAlbumTests
    {
        //[TestInitialize]

        //Todo the repository should be initialized once.
        [TestMethod]
        public void ShouldGet1Album()
        {
            var context = new Mock.Database.MockData.MockAlbumTests().MockContext;
            var repos = new RepositoryAlbum(new Uow(context.Object));

            var items = repos.GetAllAlbums();

            Assert.IsTrue(items.Count  == 1);
        }

        [TestMethod]
        public void ShouldGetNoFilteredItems()
        {
            var context = new Mock.Database.MockData.MockAlbumTests().MockContext;
            var repos = new RepositoryAlbum(new Uow(context.Object));

            var items = repos.GetFilteredAlbums("Da Album");

            Assert.IsTrue(items.Count == 0);
        }
    }
}
