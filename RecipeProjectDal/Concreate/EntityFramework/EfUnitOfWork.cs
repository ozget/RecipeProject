using RecipeProjectDal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _dbContext;
        public EfUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbcontext bos olamaz");
        }

        private ICategoryRepository _categories;
        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(_dbContext));
            }
        }
        private IAmountRepository _amounts;
        public IAmountRepository Amounts
        {
            get
            {
                return _amounts ?? (_amounts = new EfAmountRepository(_dbContext));
            }
        }
        private IIngredientRepository _ingredients;
        public IIngredientRepository Ingredients
        {
            get
            {
                return _ingredients ?? (_ingredients = new EfIngredientRepository(_dbContext));
            }
        }
        private IRecipeCategoryRepository _recipeCategories;
        public IRecipeCategoryRepository RecipeCategories
        {
            get
            {
                return _recipeCategories ?? (_recipeCategories = new EfRecipeCategoryRepository(_dbContext));
            }
        }

        private IRecipeRepository _recipes;
        public IRecipeRepository Recipes
        {
            get
            {
                return _recipes ?? (_recipes = new EfRecipeRepository(_dbContext));
            }
        }

        public IRecipeCategoryRepository Recipecategories => throw new NotImplementedException();

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
