using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace MediaFarmer.Tests.RepositoryTests
{
    class RepositoryArtistTest
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryArtist repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockAlbumTests().MockContext;
            repos = new RepositoryArtist(new Uow(context.Object));
        }
         
    }
}
