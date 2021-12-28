using Microsoft.EntityFrameworkCore;
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
        protected DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
    }
}
