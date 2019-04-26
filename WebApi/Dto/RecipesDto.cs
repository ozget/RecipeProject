using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class RecipesDto
    {
        public RecipesDto()
        {
            
            this.Ingredients = new List<IngredientDto>();
        }
        public string Title { get; set; }
        public string Directions { get; set; }
        public string[] Categories { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }

    
}
