using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private readonly IRecipeService _service;

    // pages: browse all recipes, browse planned and history recipes

    // page-browse all recipes: 
    // one icon for add new
    // title and yielded amount in units for each recipe (actions edit, delete, plan to cook)

    // page-browse history of recipes:
    // for each meal prep interval a list of recipes
    // title and yielded amount in units for each recipe
    // display corresponding shopping list for this meal plan (if exists, checked by start date within mealprep interval)
    // **pre-generate shopping list for the meal prep interval (actions save as new, merge to existing shopping list)

    public RecipeController(ILogger<RecipeController> logger, IRecipeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Recipe>> GetSingleRecipe(Guid id)
    {
        // all info about recipe
        // fetches from recipe, recipeIngredient, unitsRecipe, *units
        try
        {
            var recipe = await _service.GetSingleRecipe(id);
            return Ok(recipe);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes([FromBody] Guid userId)
    {
        // all recipe titles to browse/select to planned
        // fetches from recipe
        try
        {
            var allRecipes = await _service.GetAllRecipes(userId);
            return Ok(allRecipes);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    // api/recipes?planned=2000-01-01
    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetRecipesPlannedForDate([FromBody] Guid userId, [FromQuery] DateTime? planned)
    {
        // browse all planned recipes by dates
        // fetches from userCookedRecipe, Recipe, UnitRecipe, *Unit
        return Ok();
    }

    [HttpPost]
    public ActionResult<Recipe> AddRecipe(Guid userId, NewRecipeDto newRecipe) //takes dto
    {
        // add new recipe
        // modifies recipe, unitRecipe, recipeIngredients
        try
        {
            var recipe = _service.AddNewRecipe(userId, newRecipe);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("{id:guid}")]
    public ActionResult<Recipe> PlanRecipe(Guid id)
    {
        // adds recipe to planned from specific date
        // modifies userCookedRecipe
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> EditRecipe(Guid id, [FromBody] NewRecipeDto recipeNew) // also takes dto
    {
        // modifies recipe, unitRecipe
        try
        {
            await _service.EditRecipe(id, recipeNew);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteRecipe(Guid id)
    {
        // modifies recipe, unitRecipe
        try
        {
            await _service.DeleteRecipe(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
