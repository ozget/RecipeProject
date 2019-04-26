using Microsoft.EntityFrameworkCore;
using RecipeProjectDal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
   public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;
        public EfGenericRepository(DbContext context)
        {
            _context = context;
        }
        public T Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


        public T Find(Expression<Func<T, bool>> match)
        {
           return _context.Set<T>().SingleOrDefault(match);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GettAll()
        {
            return _context.Set<T>();
        }
        public T Update(T t, object key)
        {
            if (t==null)
            {
                return null;
            }
            T exist = _context.Set<T>().Find(key);
            if (exist!=null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            return exist;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool dispoisng)
        {
            if (!this.disposed)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
