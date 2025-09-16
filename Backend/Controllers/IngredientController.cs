

using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{id:guid}")]
    public ActionResult<Ingredient> GetSpecificIngredient(Guid id)
    {
        return Ok();
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<Ingredient> AddNewIngredient() //takes dto
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Ingredient> EditSpecificIngredient(Guid id) //also takes dto
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteSpecificIngredient(Guid id)
    {
        return Ok();
    }
 }