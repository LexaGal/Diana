using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Database.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> func = null);
        T Get(int id);
        bool Save(T value, int id);
        bool Delete(int id);
    }
}