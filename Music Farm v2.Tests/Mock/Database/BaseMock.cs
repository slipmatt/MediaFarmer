using Moq;
using UnitOfWork;
using MusicFarmer.Data;

namespace MediaFarmer.Tests.Mock.Database
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
