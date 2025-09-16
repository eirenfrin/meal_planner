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
    public async Task<ActionResult<Recipe>> GetSingleRecipe(Guid id)
    {
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
    public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
    {
        try
        {
            // var allRecipes = await _service
        }
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

    [HttpPost("{id:guid}")]
    public ActionResult<Recipe> PlanRecipe(Guid id) //also takes dto
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
