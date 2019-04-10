using StoreDbContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class Repository
    {
        protected StoreDbContext.StoreDbContext Context;

        public Repository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork as StoreDbContext.StoreDbContext;

            if (Context == null)
                throw new InvalidOperationException("UnitOfWork of the type RefuelingStationDbContext should be used while a entity framework data access are used.");
        }
    }
    public class Repository<T> : Repository, IRepository<T> where T : class
    {
        public Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        protected virtual IQueryable<T> GetMainAll()
        {
            return Context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetMainAll();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
