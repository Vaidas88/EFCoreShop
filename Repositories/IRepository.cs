using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopApp.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        void Delete(int id);
    }
}
