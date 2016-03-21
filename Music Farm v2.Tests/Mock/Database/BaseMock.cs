using Moq;
using UnitOfWork;
using MusicFarmer.Data;

namespace Music_Farm_v2.Tests.Mock.Database
{
    public class BaseMock
    {
        public Mock<MusicFarmerEntities> MockContext { get; set; }

        public BaseMock()
        {
            MockContext = new Mock<MusicFarmerEntities>();

            MockContext.As<IUow>().CallBase = false;
        }
    }
}
