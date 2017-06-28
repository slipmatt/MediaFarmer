using System;
using TrackerEnabledDbContext.Common.Interfaces;

namespace UnitOfWork
{
    public interface IUow : IDisposable, ITrackerContext
    {
        void Commit();
        IRepository<T> GetRepo<T>() where T : class;
    }
}
