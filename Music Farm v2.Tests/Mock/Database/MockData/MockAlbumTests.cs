using Music_Farm_v2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    class MockAlbumTests : BaseMock
    {
        public MockAlbumTests()
        {
            PopulateAlbums();
        }

        private void PopulateAlbums()
        {
            var items = new List<album>
            {
                new album
                {
                    album_id = 1,
                    album_name = "Test Album"
                }
            };
            MockContext.Setup(i => i.Set<album>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.albums).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
