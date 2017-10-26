
using MediaFarmer.Models;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    class MockSettingsTests : BaseMock
    {
        public MockSettingsTests()
        {
            PopulateSettings();
        }

        private void PopulateSettings()
        {
            var items = new List<SettingValue>
            {
                new SettingValue
                {
                    SettingValueId=1,
                    SettingName = "LowVolume",
                    SettingValue1 = 50,
                    Active=true
                },
                 new SettingValue
                {
                    SettingValueId=2,
                    SettingName = "Muted",
                    SettingValue1 = 30,
                    Active=true
                },
                 new SettingValue
                {
                    SettingValueId=3,
                    SettingName = "AutoQueue",
                    SettingValue1 = 1,
                    Active=true
                },
                 new SettingValue
                {
                    SettingValueId=4,
                    SettingName = "HighVolume",
                    SettingValue1 = 100,
                    Active=true
                }
            };
            MockContext.Setup(i => i.Set<SettingValue>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.SettingValues).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
