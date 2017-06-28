using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TrackerEnabledDbContext.Common.Interfaces;

namespace UnitOfWork
{
    public interface IRepository<T>: ITrackerContext where T : class
    {
        DbContext DbContext { get; set; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


        T GetById(object id);

        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);

        T GetUpdatedItem(T entity);
        
        int SaveChanges();

        IEnumerable<T> GetByQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
