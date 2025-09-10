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

    public RecipeController(ILogger<RecipeController> logger, IRecipeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Recipe> GetSingleRecipe(Guid id)
    {
        var recipe = _service.LoadRecipe(id);
        return Ok(recipe);
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Recipe>> GetAllRecipes()
    {
        return Ok();
    }

    // api/recipes?planned=2000-01-01
    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetRecipesPlannedForDate([FromQuery] DateTime? planned)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<Recipe> AddRecipe() //takes dto
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<Recipe> PlanRecipe() //takes dto
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Recipe> EditRecipe(Guid id) // also takes dto
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteRecipe(Guid id)
    {
        return Ok();
    }
}
