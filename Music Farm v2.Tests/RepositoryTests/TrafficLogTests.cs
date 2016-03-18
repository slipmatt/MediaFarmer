

namespace LeadDemandCreation.Common.Tests.Core
{
    //[TestFixture]
    //public class TrafficLogTests
    //{
    //    private ITrafficLog _trafficLog;
    //    private Mock<LeadManagementDatabaseLayer.Context.LMS.LeadManagementEntity> context;

    //    [OneTimeSetUp]
    //    public void TestSetUp()
    //    {
    //        context = new MockTrafficLogTests().MockContext;
    //        _trafficLog = new TrafficLog(new Uow(context.Object));
    //    }

    //    [Test]
    //    public void ShouldAddTrafficLog()
    //    {
    //        _trafficLog.LogTraffic(new SystemFunctionailty.Models.LMS.TrafficLogModel {
    //            IncomingIp = "TestIp",
    //            PageCode = "P1"
    //        });

    //        Assert.AreEqual(context.Object.LDCTrafficLog.Count(), 1);
    //    }

    //    [Test]
    //    public void ShouldFailTrafficLogWithPageCodeNotExisting()
    //    {
    //        var ex = Assert.Throws<Exception>(() => _trafficLog.LogTraffic(new SystemFunctionailty.Models.LMS.TrafficLogModel
    //        {
    //            IncomingIp = "TestIp",
    //            PageCode = "P2",
    //            Latitude = 1,
    //            Longitude = 1
    //        }));

    //        Assert.That(ex.Message, Is.EqualTo("Page Code does not exists"));
    //    }

    //    [Test]
    //    public void ShouldFailTrafficLogWithInvalidLocation()
    //    {
    //        var ex = Assert.Throws<Exception>(() => _trafficLog.LogTraffic(new SystemFunctionailty.Models.LMS.TrafficLogModel
    //        {
    //            IncomingIp = "TestIp",
    //            PageCode = "P1",
    //            Latitude = 190,
    //            Longitude = 190
    //        }));

    //        Assert.That(ex.Message, Is.EqualTo("Geo Location Invalid"));
    //    }
    //}
}
