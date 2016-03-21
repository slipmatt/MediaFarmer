
using Music_Farm_v2.Models;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    class MockArtistTests : BaseMock
    {
        public MockArtistTests()
        {
            PopulateArtists();
        }

        private void PopulateArtists()
        {
            var items = new List<Artist>
            {
                new Artist
                {
                    ArtistId = 1,
                    ArtistName = "Paul Van Dyk"
                },
                new Artist
                {
                    ArtistId = 2,
                    ArtistName = "Khanye West"
                },
                new Artist
                {
                    ArtistId = 3,
                    ArtistName = "TI"
                }
            };
            MockContext.Setup(i => i.Set<Artist>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Artists).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
