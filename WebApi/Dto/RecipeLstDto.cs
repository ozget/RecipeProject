using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class RecipeLstDto
    {
        public RecipeLstDto()
        {
            this.Recipes = new List<RecipesDto>();
        }
        public int Results { get; set; }
        public int Totals { get; set; }
        public List<RecipesDto> Recipes { get; set; }
    }
}
