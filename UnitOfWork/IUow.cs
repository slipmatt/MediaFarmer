using System;

namespace UnitOfWork
{
    public interface IUow : IDisposable
    {
        void Commit();
        IRepository<T> GetRepo<T>() where T : class;
    }
}
