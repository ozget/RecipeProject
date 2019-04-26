using RecipeProjectDal.Abstract;
using RecipeProjectEntity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryRepository
    {
       
        public EfCategoryRepository(ApplicationDbContext context): base(context)
        {

        }
        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}
