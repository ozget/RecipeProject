using RecipeProjectDal.Abstract;
using RecipeProjectEntity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
     public class EfRecipeRepository : EfGenericRepository<Recipe>, IRecipeRepository
    {
        public EfRecipeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}
