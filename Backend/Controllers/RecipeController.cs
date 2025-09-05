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

    [HttpGet("get-single-recipe/{id:guid}")]
    public ActionResult<Recipe> GetSingleRecipe(Guid id)
    {
        var recipe = _service.LoadRecipe(id);
        return Ok(recipe);
    }
}
