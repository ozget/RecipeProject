using RecipeProjectDal.Abstract;
using RecipeProjectEntity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
    public class EfRecipeCategoryRepository : EfGenericRepository<RecipeCategory>, IRecipeCategoryRepository
    {
        public EfRecipeCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
