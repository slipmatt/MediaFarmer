using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    public class MockVoteTests: BaseMock
    {
        public MockVoteTests()
        {
            PopulateVotes();
            PopulateUsers();
        }
        private void PopulateVotes()
        {
            var items = new List<Vote>
            {
                new Vote
                {
                    VoteId=1,
                    VoteValue=true,
                    PlayHistoryId = 1,
                    UserId=1,
                    User = new User
                    {
                        UserId=1,
                        UserName="ACER/Aspire"
                    }
                },
                new Vote
                {
                    VoteId=1,
                    VoteValue=false,
                    PlayHistoryId = 50,
                    UserId=1,
                    User = new User
                    {
                        UserId=1,
                        UserName="ACER/Aspire"
                    }
                },
                new Vote
                {
                    VoteId=2,
                    VoteValue=true,
                    PlayHistoryId = 1,
                    UserId=2,
                    User = new User
                    {
                        UserId=2,
                        UserName="Some Pleb"
                    }
                },
                new Vote
                {
                    VoteId=3,
                    VoteValue=false,
                    PlayHistoryId = 1,
                    UserId=3,
                    User = new User
                    {
                        UserId=3,
                        UserName="fwefrew"
                    }

                },
                new Vote
                {
                    VoteId=4,
                    VoteValue=true,
                    PlayHistoryId = 1,
                    UserId=4,
                    User = new User
                    {
                        UserId=4,
                        UserName="ggsgfss"
                    }
                }
            };
            MockContext.Setup(i => i.Set<Vote>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Votes).Returns(() => MockHelper.GetMockSet(items).Object);
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
