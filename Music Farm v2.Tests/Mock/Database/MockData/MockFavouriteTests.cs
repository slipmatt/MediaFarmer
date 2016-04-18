using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    class MockFavouriteTests : BaseMock
    {
        public MockFavouriteTests()
        {
            PopulateFavourites();
            PopulateUsers();
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
                    },
                    User = new User
                    {
                        UserId=1,
                        UserName="ACER\\Aspire"
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
                    },
                    User = new User
                {
                    UserId=2,
                    UserName="Some Other Pleb"
                }
                }
            };
            MockContext.Setup(i => i.Set<Favourite>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Favourites).Returns(() => MockHelper.GetMockSet(items).Object);

        }

        private void PopulateUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="ACER\\Aspire"
                }
            };
            MockContext.Setup(i => i.Set<User>()).Returns(MockHelper.GetMockSet(users).Object);
            MockContext.SetupGet(i => i.Users).Returns(() => MockHelper.GetMockSet(users).Object);

        }
    }
}

