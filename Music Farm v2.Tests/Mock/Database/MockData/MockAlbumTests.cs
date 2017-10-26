
using MediaFarmer.Models;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    class MockAlbumTests : BaseMock
    {
        public MockAlbumTests()
        {
            PopulateAlbums();
        }

        private void PopulateAlbums()
        {
            var items = new List<Album>
            {
                new Album
                {
                    AlbumId = 1,
                    AlbumName = "Test Album"
                }
            };
            MockContext.Setup(i => i.Set<Album>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Albums).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
