using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Text;
using TrackerEnabledDbContext;
using TrackerEnabledDbContext.Common.Interfaces;

namespace UnitOfWork
{
    public class Uow : TrackerContext,IUow, IDisposable
    {
        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        private DbContext DbContext { get; set; }

        public Uow(DbContext context)
        {
            DbContext = context;
        }

        public void Commit()
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

        public IRepository<T> GetRepo<T>() where T : class
        {
            return new Repository<T>(DbContext);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
