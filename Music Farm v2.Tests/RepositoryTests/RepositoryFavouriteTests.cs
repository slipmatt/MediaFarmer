using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicFarmer.Data;
using Music_Farm_v2.Context.Repositories;
using UnitOfWork;
using Music_Farm_v2.ViewModels;

namespace Music_Farm_v2.Tests.RepositoryTests
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
        }
        [TestMethod]
        public void ShouldShowAllFavouritesPerUser()
        {
            var fvm = repos.MyFavourites();
            Assert.IsTrue(fvm.Count == 1);
        }

        [TestMethod]
        public void ShouldAddUserFavourite()
        {
        }
    }
}
