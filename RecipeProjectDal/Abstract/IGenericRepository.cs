using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecipeProjectDal.Abstract
{ 
   public interface IGenericRepository<T> where T:class
    {
        T Add(T t);
        T Update(T t, object key);
        T Find(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GettAll();
        void Save();
        void Dispose();
        void Delete(T entity);

    }
}
