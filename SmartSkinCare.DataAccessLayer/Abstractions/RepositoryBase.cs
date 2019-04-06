using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartSkinCare.DataAccessLayer.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationContext _appContext;

        public RepositoryBase(ApplicationContext context)
        {
            _appContext = context;
        }

        public void Create(T entity)
        {
            _appContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _appContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _appContext.Set<T>().Where(expression);
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appContext.Set<T>().Update(entity);
        }
    }
}
