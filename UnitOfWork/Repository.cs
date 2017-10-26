using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace UnitOfWork
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State != System.Data.Entity.EntityState.Detached)
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public T GetUpdatedItem(T entity)
        {
            var dbEntityEntry = DbContext.Entry<T>(entity);

            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            return dbEntityEntry.Entity as T;
        }

        public void Delete(T entity)
        {
            if (DbContext.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);       
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return DbContext.Database.SqlQuery<T>(query, parameters);
        }

        /// <summary>
        /// This implementation of getting by query allow a person to include objects in the results.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties">Split the entity names you want to include with the ',' character</param>
        /// <returns></returns>
        public IEnumerable<T> GetByQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var logMessage = new StringBuilder();
                logMessage.AppendLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
                logMessage.AppendLine("Method Name: " + MethodBase.GetCurrentMethod().Name);
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    logMessage.AppendLine("Error Message: " + dbEntityValidationResult.ValidationErrors);
                    if (dbEntityValidationResult.Entry != null)
                    {
                        logMessage.AppendLine("---------Entity Start------------");
                        foreach (var propertyName in dbEntityValidationResult.Entry.CurrentValues.PropertyNames)
                        {
                            logMessage.AppendLine(propertyName + ": '" +
                                              dbEntityValidationResult.Entry.CurrentValues[propertyName]);
                        }
                        logMessage.AppendLine("---------Entity End------------");
                    }
                }
                throw ex;
            }
        }
    }
}
