using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookMarkManager.Dal.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected BookmarkManagerDataContext _dbContext { get; set; }
        protected DbSet<T> _dbSet { get; set; }
        public GenericRepository(BookmarkManagerDataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Insert(T item)
        {
            if (item != null)
            {
                _dbSet.Add(item);
                return _dbContext.SaveChanges() > 0;
            }
            return false;

        }
        public IEnumerable<T> GetAll(IEnumerable<Expression<Func<T, bool>>> wherePredicates, List<Expression<Func<T, object>>> includeProperties)

        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (includeProperties != null)
                foreach (var property in includeProperties)
                    query = query.Include(property);

            if (wherePredicates != null)
                foreach (var wherePredicate in wherePredicates)
                    query = query.Where(wherePredicate);


            return query.ToList();
        }
        public bool Update(int id, T item)
        {
            if (_dbSet.Find(id) != null)
            {
                _dbSet.Update(item);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }


    }
}
