using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Abstract
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository Categories { get; }
        IAmountRepository Amounts { get; }
        IIngredientRepository Ingredients { get; }
        IRecipeRepository Recipes { get; }
        IRecipeCategoryRepository RecipeCategories { get; }
        int SaveChanges();
    }
}
