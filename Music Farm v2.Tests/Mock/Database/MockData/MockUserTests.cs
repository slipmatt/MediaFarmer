using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    public class MockUserTests: BaseMock
    {
        public MockUserTests()
        {
            PopulateUsers();
        }

        public void PopulateUsers()
        {
            var items = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="ACER\\Aspire"
                },
                new User
                {
                    UserId=2,
                    UserName = "TestUser"
                }
            };
            MockContext.Setup(i => i.Set<User>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Users).Returns(() => MockHelper.GetMockSet(items).Object);

        }
    }
}
