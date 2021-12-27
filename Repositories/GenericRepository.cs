using ShopApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopApp.Repositories
{
    public abstract class GenericRepository<T>
        : IRepository<T> where T : class
    {
        protected DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
