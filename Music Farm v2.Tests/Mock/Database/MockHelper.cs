using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Music_Farm_v2.Tests.Mock.Database
{
    class MockHelper
    {
        public static Mock<DbSet<T>> GetMockSet<T>(IList<T> items) where T : class
        {
            var querable = items.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(querable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(querable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(querable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(querable.GetEnumerator());
            mockSet.Setup(i => i.Add(It.IsAny<T>())).Callback(delegate (T item) {
                items.Add(item);
            });
            return mockSet;
        }
    }
}
