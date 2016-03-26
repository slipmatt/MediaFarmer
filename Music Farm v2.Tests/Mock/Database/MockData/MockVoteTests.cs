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
        }
        private void PopulateVotes()
        {
            var items = new List<Vote>
            {
                new Vote
                {
                    VoteId=1,
                    VoteValue=true,
                    PlayhistoryId = 1,
                    UserId=1
                },
                new Vote
                {
                    VoteId=2,
                    VoteValue=true,
                    PlayhistoryId = 1,
                    UserId=2
                },
                new Vote
                {
                    VoteId=3,
                    VoteValue=false,
                    PlayhistoryId = 1,
                    UserId=3
                },
                new Vote
                {
                    VoteId=4,
                    VoteValue=true,
                    PlayhistoryId = 1,
                    UserId=4
                }
            };
            MockContext.Setup(i => i.Set<Vote>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Votes).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
