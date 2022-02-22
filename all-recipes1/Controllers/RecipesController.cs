using all_recipes1.Data.Services;
using all_recipes1.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace all_recipes1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public RecipesService _recipesService;
        public RecipesController(RecipesService recipesService)

        {
            _recipesService = recipesService;
        }

        [HttpGet("get-all-recipes")]
        public IActionResult GetAllRecipes()
        {
            var allRecipes = _recipesService.GetAllRecipes();
            return Ok(allRecipes);
        }
        [HttpGet("get-recipe-by-id/{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipesService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpPost("add-recipe")]
        public IActionResult AddRecipe([FromBody]RecipeVM recipe)
        {
            _recipesService.AddRecipe(recipe);
            return Ok();
                }
        [HttpPut("update-recipe-by-id/{id}")]
        public IActionResult UpdateRecipeById(int id, [FromBody] RecipeVM recipe)
        {
                var updatedRecipe= _recipesService.UpdateRecipeById(id,recipe);
            return Ok(updatedRecipe); }
        [HttpDelete("delete-recipe-by-id/{id}")]
        public IActionResult DeleteRecipeById(int id)
        {
            _recipesService.DeleteRecipeById(id);
            return Ok();
        }
    }
}
