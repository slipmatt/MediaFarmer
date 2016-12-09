using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using MediaFarmer.Context.Repositories;
using UnitOfWork;
using MediaFarmer.ViewModels;
using MediaFarmer.Tests.RepositoryTests.Helpers;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryFavouriteTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryFavourite repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockFavouriteTests().MockContext;
            repos = new RepositoryFavourite(new Uow(context.Object));
            MockIIS.MockIISHost();
        }
        [TestMethod]
        [Ignore]
        public void ShouldShowAllFavouritesPerUser()
        {
            var fvm = repos.MyFavourites();
            Assert.AreEqual(fvm.Count,0);
        }

        [TestMethod]
        public void ShouldCheckIfFavouriteExists()
        {
            var fvm = repos.FavouriteExists(1, 1);
            Assert.IsTrue(fvm);
        }
    }
}
