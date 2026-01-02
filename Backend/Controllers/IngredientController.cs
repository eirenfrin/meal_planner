
using Backend.Dtos;
using Backend.Extensions;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly ILogger<IngredientController> _logger;
    private readonly IIngredientService _service;

    public IngredientController(ILogger<IngredientController> logger, IIngredientService service)
    {
        _logger = logger;
        _service = service;
    }

    // Page: browse all ingredients

    [Authorize]
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetIngredientDto>>> GetAllIngredients()
    {
        // list all possible ingredients
        // fetch info from ingredient and unit in which its sold
        var userId = User.GetUserId();
        var allIngredients = await _service.GetAllIngredients(userId);

        return Ok(allIngredients);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GetIngredientDto>> AddNewIngredient([FromBody] NewEditIngredientDto newIngredient) //takes dto
    {
        // modifies ingredient
        var userId = User.GetUserId();
        var ingredient = await _service.AddNewIngredient(userId, newIngredient);
        return Ok(ingredient);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> EditSpecificIngredient(Guid id, [FromBody] NewEditIngredientDto ingredientModified)
    {
        // modifies ingredient
        await _service.EditIngredient(id, ingredientModified);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteSpecificIngredient(Guid id)
    {
        // modifies ingredient
        await _service.DeleteIngredient(id);
        return Ok();
    }

    [Authorize]
    [HttpPost("delete-multiple")]
    public async Task<ActionResult> DeleteBatchIngredients([FromBody] BatchDeleteDto idsToDelete)
    {
        await _service.BatchDeleteIngredients(idsToDelete);
        return Ok();
    }
}