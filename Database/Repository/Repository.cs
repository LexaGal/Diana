using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//using Database.EFModel;
using Database.Helpers;

namespace Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private АвтозаправкиEntities _context;

        public Repository(АвтозаправкиEntities context)
        {
            _context = context;
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> func = null)
        {
            using (_context = new АвтозаправкиEntities())
            {
                if (func != null)
                    return _context.Set<T>().Where(func).ToList();
                return _context.Set<T>().ToList();
            }
        }

        public virtual T Get(int id)
        {
            using (_context = new АвтозаправкиEntities())
            {
                return _context.Set<T>().Find(id);
            }
        }

        public virtual bool Save(T value, int id)
        {
            using (_context = new АвтозаправкиEntities())
            {
                var t = _context.Set<T>().Find(id);
                if (t == null)
                {
                    _context.Set<T>().Add(value);
                    _context.SaveChanges();
                    return true;
                }
                value.CopyPropertiesTo(t);
                return true;
            }
        }
        
        public virtual bool Delete(int id)
        {
            using (_context = new АвтозаправкиEntities())
            {
                var t = _context.Set<T>().Find(id);
                if (t != null)
                {
                    _context.Set<T>().Remove(t);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public virtual void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}