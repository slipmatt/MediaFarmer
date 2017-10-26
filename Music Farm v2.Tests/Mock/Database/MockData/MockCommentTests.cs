using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    class MockCommentTests:BaseMock
    {
        public MockCommentTests()
        {
            PopulateComments();
            PopulateUsers();
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
                    PlayHistoryId=1,
                    User=new User
                    {
                        UserId=1,
                        UserName="acer\\aspire"
                    }
                },
                new Comment
                {
                    CommentId=1,
                    CommentText="This Really Sucks",
                    UserId=1,
                    PlayHistoryId=2,
                    User =new User
                    {
                        UserId=1,
                        UserName="acer\\aspire"
                    }
                }
            };
            
            MockContext.Setup(i => i.Set<Comment>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Comments).Returns(() => MockHelper.GetMockSet(items).Object);
        }

        private void PopulateUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="acer\\aspire"
                }
            };
            MockContext.Setup(i => i.Set<User>()).Returns(MockHelper.GetMockSet(users).Object);
            MockContext.SetupGet(i => i.Users).Returns(() => MockHelper.GetMockSet(users).Object);

        }
    }
}
