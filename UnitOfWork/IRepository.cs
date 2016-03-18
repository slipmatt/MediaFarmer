using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWork
{
    public interface IRepository<T> where T : class
    {
        DbContext DbContext { get; set; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetUpdatedItem(T entity);

        //GetById does not work for unit testing with mock database
        T GetById(object id);
        
        void SaveChanges();

        IEnumerable<T> GetByQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
