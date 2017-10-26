using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaFarmer.Context.Repositories;
using MediaFarmer.ViewModels;
using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace MediaFarmer.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryUserTests
    {
        Moq.Mock<MusicFarmerEntities> context;
        RepositoryUser repos;

        [TestInitialize]
        public void InitializeTests()
        {
            context = new Mock.Database.MockData.MockUserTests().MockContext;
            repos = new RepositoryUser(new Uow(context.Object));
        }

        [TestMethod]
        public void ShouldGetUserIdFromUserName()
        {
            int? UID = repos.GetUserId("acer\\aspire");
            Assert.AreEqual(1, UID);
        }

        [TestMethod]
        public void ShouldCheckIfUserDoesNotExist()
        {
            bool userExists = repos.CheckIfUserExists("SomeNoob");
            Assert.AreEqual(false,userExists);
        }
        [TestMethod]
        public void ShouldCheckIfUserDoesExist()
        {
            bool userExists = repos.CheckIfUserExists("acer\\aspire");
            Assert.AreEqual(true,userExists);
        }

        [TestMethod]
        public void ShouldCreateNewUser()
        {
            repos.CreatUser("SomeUser");
            Assert.IsTrue(context.Object.Users.Count(i=>i.UserName=="SomeUser")==1);
          //  Assert.AreEqual(true, userExists);
        }
    }
}
