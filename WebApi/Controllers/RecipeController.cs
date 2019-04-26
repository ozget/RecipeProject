using Microsoft.AspNetCore.Mvc;
using RecipeProjectDal.Abstract;
using RecipeProjectEntity.Concreate;
using System;
using WebApi.Dto;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
     [Produces("application/json")]
    public class RecipeController : ControllerBase
    {
        private readonly IUnitOfWork _uofw;


        public RecipeController(IUnitOfWork uofw)
        {
            _uofw = uofw;

        }
        

        [HttpPost]
        [Route("services/recipe/all")]
        public IActionResult All([FromBody]FilterCategory filter) // kategory id göre fitreleme
        {
            try
            {

                var recipes = _uofw.Recipes.FindBy(f => f.Categories.Any(h => filter.CategoryIds.Contains(h.CategoryId))).Select(g => new RecipesDto()
                {
                    Title = g.Title,
                    Categories = g.Categories.Select(j => j.Category.Name).ToArray(),
                    Directions = g.Desciription,
                    Ingredients = g.Ingredients.Select(k => new IngredientDto()
                    {
                        Name=k.Name,
                        Amounts=k.Amounts.Select(l=>new AmountDto()
                        {
                            Quantity=l.Quantity,
                            Unit=l.Unit,
                        }).ToList()


                    }).ToList()
                    
                }).ToList();
                if (recipes.Count==0)
                {
                    return StatusCode(204, "No recipes found");
                }

                RecipeLstDto reciplst = new RecipeLstDto()
                {
                    Results=recipes.Count(),
                    Recipes=recipes.ToList(),
                    Totals=_uofw.Recipes.GettAll().Count()
                    
                };
                
               return Ok(reciplst);
            }
            catch (Exception)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

        }


        // GET: services/<controller>
        [HttpGet]
        [Route("services/recipe/filter/categories")]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _uofw.Categories.GettAll().Select(f => f.Name).ToArray();

                CategoryList cat = new CategoryList()
                {
                    Categories = categories,
                    Results = categories.Count()
                };


                if (categories == null)
                {
                    return NotFound("The Recipe record couldn't be found.");


                }

                return Ok(cat);
            }
            catch (Exception)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }


        }

        

        [HttpPost] 
        [Route("services/recipe/add")]// 3 soru
        public IActionResult Add([FromBody]RecipesDto recipe)
        {
            try
            {
                   
                if (recipe == null)
                {
                    return BadRequest(); // 400 
                }
                               
                var RecipeValueAdd = _uofw.Recipes.FindBy(f=>f.Title.Equals(recipe.Title)||f.Desciription.Equals(recipe.Directions)).FirstOrDefault();

                var categories = _uofw.Categories.FindBy(f => recipe.Categories.Contains(f.Name));

                if (RecipeValueAdd == null)
                {
                    Recipe rec = new Recipe()
                    {
                        Title=recipe.Title,
                        Desciription=recipe.Directions,
                        
                    };
                    foreach (var category in categories)
                    {
                        rec.Categories.Add(new RecipeCategory() {Category=category });
                    }

                    foreach (var item in recipe.Ingredients)
                    {

                        Ingredient ingred = new Ingredient()
                        {
                            Name=item.Name,
                            

                        };

                        foreach (var amount in item.Amounts)
                        {
                            ingred.Amounts.Add(new Amount() { Quantity = amount.Quantity, Unit = amount.Unit });
                        }

                        rec.Ingredients.Add(ingred);
                    }

                    _uofw.Recipes.Add(rec);
                     int resulr=  _uofw.SaveChanges();
                                       
                }

                                
                return StatusCode(201, "Recipe created ");
            }
            catch (Exception)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }


        }

       


    }
}
