
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipeProjectEntity.Concreate
{
    public class Amount
    {
        [Key]
        public int AmountId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
