

using System.ComponentModel;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;
using Backend.Services;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients(Guid userId)
    {
        // list all possible ingredients
        // fetch info from ingredient and unit in which its sold
        try
        {
            var allIngredients = await _service.GetAllIngredients(userId);
            return Ok(allIngredients);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Ingredient>> AddNewIngredient([FromBody] NewIngredientDto newIngredient) //takes dto
    {
        // modifies ingredient
        try
        {
            var ingredient = await _service.AddNewIngredient(newIngredient);
            return Ok(ingredient);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> EditSpecificIngredient(Guid id, [FromBody] EditIngredientDto ingredientModified)
    {
        // modifies ingredient
        try
        {
            await _service.EditIngredient(id, ingredientModified);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteSpecificIngredient(Guid id)
    {
        // modifies ingredient
        try
        {
            await _service.DeleteIngredient(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
 }