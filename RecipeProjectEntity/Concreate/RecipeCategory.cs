using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectEntity.Concreate
{
    public class RecipeCategory
    {
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }
        public Category Category { get; set; }
        public Recipe Recipe { get; set; }
    }
}
