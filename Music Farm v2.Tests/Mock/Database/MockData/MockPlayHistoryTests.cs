using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    class MockPlayHistoryTests : BaseMock
    {
        public MockPlayHistoryTests()
        {
            PopulatePlayHistories();
            PopulateUsers();
        }

        private void PopulatePlayHistories()
        {
            var items = new List<PlayHistory>
            {
                new PlayHistory
                {
                    PlayHistoryId=1,
                    PlayCompleted=false,
                    IsPlaying=true,
                    UserId = 1,
                    TrackId = 1,
                    Track=new Track {TrackId=1,TrackName="Test Track",TrackURL="C:\\Track1.mp3"},
                    User=new User { UserId=1,UserName="ACER/Aspire", Active=true }
                },
                new PlayHistory
                {
                    PlayHistoryId=2,
                    PlayCompleted=false,
                    IsPlaying=false,
                    UserId = 2,
                    TrackId = 1,
                    Track=new Track {TrackId=1,TrackName="Test Track",TrackURL="C:\\Track1.mp3"},
                    User=new User { UserId=2,UserName="TestUser", Active=true }
                },
                new PlayHistory
                {
                    PlayHistoryId=3,
                    PlayCompleted=false,
                    IsPlaying=false,
                    UserId = 2,
                    TrackId = 2,
                    Track=new Track {TrackId=2,TrackName="Test Track Volume 2",TrackURL="C:\\Track2.mp3"},
                    User=new User { UserId=2,UserName="TestUser", Active=true  }
                }
                ,
                new PlayHistory
                {
                    PlayHistoryId=4,
                    PlayCompleted=true,
                    IsPlaying=false,
                    UserId = 2,
                    TrackId = 4,
                    Track=new Track {TrackId=4,TrackName="Test Track Volume 4",TrackURL="C:\\Track4.mp3"},
                    User=new User { UserId=2,UserName="TestUser", Active=true  }
                }
            };
            MockContext.Setup(i => i.Set<PlayHistory>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.PlayHistories).Returns(() => MockHelper.GetMockSet(items).Object);
        }

        private void PopulateUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="ACER/Aspire"
                }
            };
            MockContext.Setup(i => i.Set<User>()).Returns(MockHelper.GetMockSet(users).Object);
            MockContext.SetupGet(i => i.Users).Returns(() => MockHelper.GetMockSet(users).Object);

        }
    }
}
