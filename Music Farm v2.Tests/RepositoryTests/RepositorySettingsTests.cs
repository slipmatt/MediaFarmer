using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using UnitOfWork;
using MusicFarmer.Data;
using MediaFarmer.ViewModels;
using System.Linq;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositorySettingsTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositorySettings repos;

        [TestInitialize]
        public void InitializeTests()
        {
             context = new Mock.Database.MockData.MockSettingsTests().MockContext;
             repos= new RepositorySettings(new Uow(context.Object));
        }

        [TestMethod]
        public void RepositorySettingsTests_GetAll_ShouldReturn4Settings()
        {
            //Arrange
            var expected = 4;

            //Act
            var actual = repos.GetAllSettings().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositorySettingsTests_GivenCorrectSettingName_ShouldReturnTheSetting()
        {
            //Arrange
            var expected = 1;

            //Act
            var actual = repos.GetFilteredSettingsByName("Low").Count;

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void RepositorySettingsTests_GivenPartialSettingName_ShouldReturnSettingsWithATextMatch()
        {
            //Arrange
            var expected = 2;

            //Act
            var actual = repos.GetFilteredSettingsByName("Volume").Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositorySettingsTests_GivenSettingId_ShouldReturnSpecificSetting()
        {
            //Arrange
            var expected = "LowVolume";

            //Act
            var actual = repos.GetFilteredSettingsById(1).SettingName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositorySettingsTests_GivenANewSetting_ShouldAddTheSetting()
        {
            //Arrange
            var expected = 1;

            //Act
            var setting = new SettingValueViewModel
            {
                SettingId = 5,
                SettingName = "Test",
                SettingValue = 1,
                Active = true
            };

            repos.AddSetting(setting);

            //Assert
            var actual = context.Object.SettingValues.Count(i => i.SettingName == "Test");
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void RepositorySettingsTests_GivenAnUpdatedSetting_ShouldUpdateTheSetting()
        {
            //Arrange
            var expected = 1;

            //Act
            var setting = new SettingValueViewModel
            {
                SettingId = 1,
                SettingName = "LowVolume",
                SettingValue = 30,
                Active = true
            };

            repos.UpdateSetting(setting);

            //Assert
            var actual = context.Object.SettingValues.Count(i => i.SettingName == "LowVolume" && i.SettingValue1==30);
            Assert.AreEqual(expected, actual);
        }
    }
}
