using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookMarkManager.Dal
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByID(int id);
        IEnumerable<T> GetAll(IEnumerable<Expression<Func<T, bool>>> wherePredicates, List<Expression<Func<T, object>>> includeProperties);
        bool Insert(T item);
        bool Update(int id, T item);
        bool Delete(int id);
    }
}
