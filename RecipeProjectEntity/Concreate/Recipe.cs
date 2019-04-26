
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeProjectEntity.Concreate
{
    public class Recipe
    {
        public Recipe()
        {
            this.Categories = new HashSet<RecipeCategory>();
            this.Ingredients = new HashSet<Ingredient>();
        }
        public int RecipeId { get; set; }
        public string Title { get; set; }     
        public string Desciription { get; set; }
        public ICollection<RecipeCategory> Categories { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
