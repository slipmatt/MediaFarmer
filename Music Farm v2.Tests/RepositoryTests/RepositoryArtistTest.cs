using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music_Farm_v2.Context.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Music_Farm_v2.Tests.RepositoryTests
{
    class RepositoryArtistTest
    {
        Moq.Mock<Data.MusicFarmerEntities> context;
        RepositoryArtist repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockAlbumTests().MockContext;
            repos = new RepositoryArtist(new Uow(context.Object));
        }
    }
}
