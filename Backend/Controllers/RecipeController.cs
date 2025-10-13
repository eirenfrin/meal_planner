using Backend.Dtos;
using Backend.Extensions;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetRecipeAllInfoDto>> GetSingleRecipe(Guid id)
    {
        // all info about recipe
        // fetches from recipe, recipeIngredient, unitsRecipe, *units
        var recipe = await _service.GetSingleRecipe(id);
        return Ok(recipe);
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetRecipeBasicInfoDto>>> GetAllRecipes()
    {
        // all recipe titles to browse/select to planned
        // fetches from recipe
        var userId = User.GetUserId();
        var allRecipes = await _service.GetAllRecipes(userId);

        return Ok(allRecipes);
    }

    // api/recipes?planned=2000-01-01
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPlannedRecipesDto>>> GetRecipesPlannedForDate([FromQuery] DateTime planned)
    {
        // browse all planned recipes by dates
        // fetches from userCookedRecipe, Recipe, UnitRecipe, *Unit
        var userId = User.GetUserId();
        var plannedRecipes = await _service.GetRecipesPlannedForDate(userId, planned);

        return Ok(plannedRecipes);
    }

    [Authorize]
    [HttpPost]
    public ActionResult<GetRecipeAllInfoDto> AddRecipe([FromBody] NewEditRecipeDto newRecipe) //takes dto
    {
        // add new recipe
        // modifies recipe, unitRecipe, recipeIngredients
        var userId = User.GetUserId();
        var recipe = _service.AddNewRecipe(userId, newRecipe);
        return Ok(recipe);
    }

    [HttpPost("{id:guid}")]
    public ActionResult<Recipe> PlanRecipe(Guid id)
    {
        // adds recipe to planned from specific date
        // modifies userCookedRecipe
        return Ok();
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> EditRecipe(Guid id, [FromBody] NewEditRecipeDto recipeNew) // also takes dto
    {
        // modifies recipe, unitRecipe
        var userId = User.GetUserId();
        await _service.EditRecipe(userId, id, recipeNew);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteRecipe(Guid id)
    {
        // modifies recipe, unitRecipe
        await _service.DeleteRecipe(id);
        return Ok();
    }
}
