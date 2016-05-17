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
    public class RepositoryJukeBoxTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryJukeBox repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockJukeBoxTests().MockContext;
            repos = new RepositoryJukeBox(new Uow(context.Object));
        }
        [TestMethod]
        public void ShouldGetJukeBoxTracks()
        {
            var items = repos.GetJukeBoxTracks();
            Assert.IsTrue(items.Count == 2);
        }
    }
}
