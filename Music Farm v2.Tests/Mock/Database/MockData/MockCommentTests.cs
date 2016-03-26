using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    class MockCommentTests:BaseMock
    {
        public MockCommentTests()
        {
            PopulateComments();
        }
        private void PopulateComments()
        {
            var items = new List<Comment>
            {
                new Comment
                {
                    CommentId=1,
                    CommentText="This Sucks",
                    UserId=1,
                    PlayHistoryId=1
                },
                new Comment
                {
                    CommentId=1,
                    CommentText="This Really Sucks",
                    UserId=1,
                    PlayHistoryId=2
                }
            };
            MockContext.Setup(i => i.Set<Comment>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Comments).Returns(() => MockHelper.GetMockSet(items).Object);

        }
    }
}
