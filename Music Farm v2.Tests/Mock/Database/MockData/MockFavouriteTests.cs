using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    class MockFavouriteTests : BaseMock
    {
        public MockFavouriteTests()
        {
            PopulateFavourites();
        }
        private void PopulateFavourites()
        {
            var items = new List<Favourite>
            {
                new Favourite
                {
                    FavouriteId=1,
                    UserId=1,
                    TrackId=1,
                    Track=new Track
                    {
                        TrackId=1,
                        TrackName="User1's Favourite Track"
                    }
                },
                new Favourite
                {
                    FavouriteId=2,
                    UserId=2,
                    TrackId=1,
                    Track=new Track
                    {
                        TrackId=1,
                        TrackName="User1's Favourite Track"
                    }
                }
            };
            MockContext.Setup(i => i.Set<Favourite>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Favourites).Returns(() => MockHelper.GetMockSet(items).Object);

        }
    }
}

