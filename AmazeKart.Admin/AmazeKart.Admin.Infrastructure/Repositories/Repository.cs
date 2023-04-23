using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected AmazeKartDB Context = null;

        public Repository(IUnitOfWork uow)
        {
            Context = uow.dbContext;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public virtual IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public virtual TObject FindOne(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<TObject> Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<TObject> FindAsNoTracking(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TObject Create(TObject TObject)
        {
            HandleError_IDENTITY_INSERT(TObject);

            DbSet.Add(TObject);
            return TObject;
        }

        /// <summary>
        /// Handle below exception
        /// SqlException: Cannot insert explicit value for identity column in table 'TABLE_NAME' when IDENTITY_INSERT is set to OFF.
        /// </summary>
        private void HandleError_IDENTITY_INSERT(TObject TObject)
        {
            try
            {
                var id_prop = TObject.GetType().GetProperties().FirstOrDefault(IsDatabaseGeneratedId);
                if (id_prop != null)
                {
                    id_prop.SetValue(TObject, 0);
                }
            }
            catch (Exception ex) { }
        }

        static bool IsDatabaseGeneratedId(PropertyInfo propertyInfo)
        {
            return propertyInfo
                .GetCustomAttributes(typeof(DatabaseGeneratedAttribute))
                .Cast<DatabaseGeneratedAttribute>()
                .Any(a => a.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity);
        }

        public virtual void CreateMany(IEnumerable<TObject> TObject)
        {
            DbSet.AddRange(TObject);
        }

        public virtual int Counts(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual int Delete(TObject TObject)
        {
            DbSet.Remove(TObject);
            return 0;
        }

        public virtual int Delete(Expression<Func<TObject, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return 0;
        }

        public IEnumerable<TObject> DeleteMany(List<TObject> t)
        {
            DbSet.RemoveRange(t);
            return null;
        }

        public virtual int Update(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return 0;
        }

        public virtual bool Any(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual void SetValues(object DestinationValue, object SourceValue)
        {
            Context.Entry(DestinationValue).CurrentValues.SetValues(SourceValue);
        }
    }
}