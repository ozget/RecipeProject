
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace RecipeProjectEntity.Concreate
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Amounts = new HashSet<Amount>();
        }   
        [Key]
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
        public ICollection<Amount> Amounts { get; set; }
       

    }
}
