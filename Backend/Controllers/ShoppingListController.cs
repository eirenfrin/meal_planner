

using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ILogger<ShoppingListController> _logger;
    // private readonly IShoppingListService _service;

    public ShoppingListController(ILogger<ShoppingListController> logger/*, IShoppingListService service*/)
    {
        _logger = logger;
        //_service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ShoppingList> GetSingleShoppingList(Guid id)
    {
        return Ok();
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<ShoppingList>> GetAllShoppingLists()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<ShoppingList> CreateNewShoppingList() //takes dto
    {
        return Ok();
    }

    [HttpPost("generated")]
    public ActionResult<ShoppingList> GenerateShoppingListFromPlannedRecipes() //takes dto
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<ShoppingList> EditShoppingList(Guid id) //takes dto
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteSingleShoppingList(Guid id)
    {
        return Ok();
    }

}